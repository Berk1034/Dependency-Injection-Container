using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionContainerLibraryUTests.TestClasses
{
    public class BarFromInterface : IBar
    {
        AbstractFoo Foo;

        public BarFromInterface(AbstractFoo foo)
        {
            Foo = foo;
        }
    }
}
