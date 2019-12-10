using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjectionContainer
{
    public interface AInterface
    {
        string GetMe();
    }

    public class A : AInterface
    {
        bool b;

        public A(bool k)
        {
            b = k;
        }

        public string GetMe()
        {
            return "A";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DependencyConfiguration dc = new DependencyConfiguration();
            dc.Register<AInterface, A>();
//            dc.Register<A, A>();
            DependencyProvider dp = new DependencyProvider(dc);

            var b = typeof(A).IsGenericType;

            var k = dp.Resolve<AInterface>();
            Console.WriteLine(k.GetMe());
            Console.ReadLine();
        }
    }
}
