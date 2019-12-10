using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionContainer
{
    public class DependencyProvider
    {
        private readonly DependencyConfiguration dependencyConfiguration;
        private readonly ConcurrentStack<Type> Implementations;
        private static readonly object syncRoot = new object();

        public DependencyProvider(DependencyConfiguration dependencyConfiguration)
        {
            if (Validate(dependencyConfiguration))
            {
                this.dependencyConfiguration = dependencyConfiguration;
                Implementations = new ConcurrentStack<Type>();
            }
            else
            {
                throw new Exception("Dependency Configuration is not valid");
            }
        }

        private bool Validate(DependencyConfiguration dependencyConfiguration)
        {
            if(dependencyConfiguration != null)
            {
                foreach(var kvpair in dependencyConfiguration.Configuration)
                {
                    foreach(var confType in kvpair.Value)
                    {
                        if (confType.Implementation.IsAbstract || confType.Implementation.IsInterface|| !confType.ImplementationInterface.IsAssignableFrom(confType.Implementation))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public T Resolve<T>()
        {
            var type = typeof(T);
            var configuratedType = dependencyConfiguration.GetConfiguratedType(type);

            if (configuratedType != null)
            {
                return (T)GetOrCreateInstance(configuratedType);
            }
            else
            {
                return default(T);
            }

        }

        private object Create(Type type)
        {
            var configuratedType = dependencyConfiguration.GetConfiguratedType(type);

            if(configuratedType != null)
            {
                if(configuratedType.IsSingleton && configuratedType.Instance != null)
                {
                    return configuratedType.Instance;
                }

                if (!Implementations.Contains(configuratedType.Implementation))
                {
                    Implementations.Push(configuratedType.Implementation);

                    ConstructorInfo[] constructors = configuratedType.Implementation.GetConstructors().OrderByDescending(x => x.GetParameters().Length).ToArray();

                    object result = null;

                    bool isCreated = false;
                    int ctorNum = 1;

                    while (!isCreated && ctorNum <= constructors.Count())
                    {
                        try
                        {
                            ConstructorInfo useConstructor = constructors[ctorNum - 1];
                            object[] parameters = GetConstructorParams(useConstructor);
                            result = Activator.CreateInstance(configuratedType.Implementation, parameters);
                            isCreated = true;
                        }
                        catch
                        {
                            isCreated = false;
                            ctorNum++;
                        }
                    }

                    if (!Implementations.TryPop(out var temp))
                    {
                        return null;
                    }

                    if (isCreated)
                    {
                        return result;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private object[] GetConstructorParams(ConstructorInfo constructor)
        {
            ParameterInfo[] parameters = constructor.GetParameters();
            object[] parametersValues = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                parametersValues[i] = GetOrCreateInstance(dependencyConfiguration.GetConfiguratedType(parameters[i].ParameterType));
            }

            return parametersValues;
        }

        private object GetOrCreateInstance(ConfiguratedType configuratedType)
        {
            if (configuratedType != null)
            {
                if (configuratedType.IsSingleton)
                {
                    if (configuratedType.Instance == null)
                    {
                        lock (syncRoot)
                        {
                            if (configuratedType.Instance == null)
                            {
                                configuratedType.Instance = Create(configuratedType.ImplementationInterface);
                            }
                        }
                    }
                    return configuratedType.Instance;
                }

                return Create(configuratedType.ImplementationInterface);
            }
            else
            {
                return null;
            }
        }
    }
}
