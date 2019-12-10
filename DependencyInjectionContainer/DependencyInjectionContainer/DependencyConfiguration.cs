using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionContainer
{
    public class DependencyConfiguration
    {
        private readonly Dictionary<Type, List<ConfiguratedType>> _configuration;

        public DependencyConfiguration()
        {
            _configuration = new Dictionary<Type, List<ConfiguratedType>>();
        }

        public void Register<TImplementation>()
        {
            RegisterType(typeof(TImplementation), typeof(TImplementation));
        }

        public void Register<TInterface, TImplementation>()
        {
            RegisterType(typeof(TInterface), typeof(TImplementation));
        }

        public void Register(Type TInterface, Type TImplementation)
        {
            RegisterType(TInterface, TImplementation);
        }

        public void RegisterSingleton<TImplementation>()
        {
            RegisterType(typeof(TImplementation), typeof(TImplementation), true);
        }

        public void RegisterSingleton<TInterface, TImplementation>()
        {
            RegisterType(typeof(TInterface), typeof(TImplementation), true);
        }

        public void RegisterSingleton(Type TInterface, Type TImplementation)
        {
            RegisterType(TInterface, TImplementation, true);
        }

        public void RegisterType(Type TInterface, Type TImplementation, bool isSingleton = false)
        {
            ConfiguratedType configuratedType = new ConfiguratedType(TInterface, TImplementation, isSingleton);
            _configuration.Add(TInterface, new List<ConfiguratedType>() { configuratedType });
        }
    }
}
