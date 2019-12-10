using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionContainer
{
    public class ConfiguratedType
    {
        public bool IsSingleton { get; set; }

        public Type ImplementationInterface { get; }

        public Type Implementation { get; }

        public object Instance { get; set; }

        public ConfiguratedType(Type implementation, Type interf, bool isSingleton = false)
        {
            Implementation = implementation;
            ImplementationInterface = interf;
            IsSingleton = isSingleton;
            Instance = null;
        }
    }
}
