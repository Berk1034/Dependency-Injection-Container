using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionContainerLibraryUTests.TestClasses
{
    public interface IGenericFoo<TInterface>
        where TInterface : IFoo
    {
        TInterface DoSmth();
    }
}
