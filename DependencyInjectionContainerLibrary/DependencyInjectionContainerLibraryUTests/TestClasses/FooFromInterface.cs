using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionContainerLibraryUTests.TestClasses
{
    public class FooFromInterface : IFoo
    {
        public AbstractBar Bar;

        public FooFromInterface(AbstractBar bar)
        {
            Bar = bar;
        }

        public void GetMe()
        {
            throw new NotImplementedException();
        }
    }
}
