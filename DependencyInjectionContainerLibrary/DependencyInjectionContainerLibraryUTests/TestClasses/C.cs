using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionContainerLibraryUTests.TestClasses
{
    public class C : CInterface
    {
        public IEnumerable<DInterface> dEnum { get; }

        public C(IEnumerable<DInterface> d)
        {
            dEnum = d;
        }
    }
}
