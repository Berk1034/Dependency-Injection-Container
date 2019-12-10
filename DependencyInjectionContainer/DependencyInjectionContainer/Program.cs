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
        }
    }
}
