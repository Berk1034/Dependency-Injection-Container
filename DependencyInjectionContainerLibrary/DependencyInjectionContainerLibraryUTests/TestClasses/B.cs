using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionContainerLibraryUTests.TestClasses
{
    public class B : BInterface
    {
        AInterface a;

        public B(AInterface A)
        {
            a = A;
        }
    }
}
