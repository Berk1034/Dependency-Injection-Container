using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionContainerLibraryUTests.TestClasses
{
    public class GenericFoo<TInterface> : IGenericFoo<TInterface> where TInterface : IFoo
    {
        public TInterface DoSmth()
        {
            throw new NotImplementedException();
        }
    }
}
