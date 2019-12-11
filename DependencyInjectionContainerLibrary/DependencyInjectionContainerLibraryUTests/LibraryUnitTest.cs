using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DependencyInjectionContainerLibraryUTests.TestClasses;
using DependencyInjectionContainerLibrary;

namespace DependencyInjectionContainerLibraryUTests
{
    [TestClass]
    public class LibraryUnitTest
    {
        [TestMethod]
        public void ShouldRegisterInstancePerDependency()
        {
            DependencyConfiguration dependencyConfiguration = new DependencyConfiguration();
            dependencyConfiguration.Register<IBar, BarFromInterface>();

            DependencyProvider dependencyProvider = new DependencyProvider(dependencyConfiguration);

            var bar1 = dependencyProvider.Resolve<IBar>();
            var bar2 = dependencyProvider.Resolve<IBar>();

            Assert.AreNotEqual(bar1, bar2);
        }

        [TestMethod]
        public void ShouldRegisterSingleton()
        {
            DependencyConfiguration dependencyConfiguration = new DependencyConfiguration();
            dependencyConfiguration.RegisterSingleton<AbstractBar, BarFromAbstract>();

            DependencyProvider dependencyProvider = new DependencyProvider(dependencyConfiguration);

            var bar1 = dependencyProvider.Resolve<AbstractBar>();
            var bar2 = dependencyProvider.Resolve<AbstractBar>();

            Assert.AreEqual(bar1, bar2);
        }
    }
}
