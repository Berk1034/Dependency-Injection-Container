using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionContainerLibraryUTests.TestClasses
{
    public abstract class AbstractFoo : IFoo
    {
        public void GetMe()
        {
            throw new NotImplementedException();
        }
    }
}
