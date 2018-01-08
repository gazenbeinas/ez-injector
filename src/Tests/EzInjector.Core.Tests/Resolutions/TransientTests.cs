using EzInjector.TestUtils.Concretes.Concrete.WithDependency;
using EzInjector.TestUtils.Concretes.Concrete.WithoutDependency;
using EzInjector.TestUtils.Concretes.Implementations;
using EzInjector.TestUtils.Interfaces;
using Xunit;

namespace EzInjector.Core.Tests.Resolutions
{
    public class TransientTests
    {
        readonly Container _container;

        public TransientTests()
        {
            _container = new Container();
        }

        [Fact]
        public void ResolveBy_ConcreteType_WithoutDependencies_ReturnsInstance()
        {
            Assert.IsType<SimpleConcreteClassOne>(
                _container.Resolve<SimpleConcreteClassOne>());
        }

        [Fact]
        public void ResolveBy_ConcreteType_WithDependencies_ReturnsInstance()
        {
            var instance = _container
                .Resolve<ConcreteClassWithDependencies>();

            Assert.IsType<ConcreteClassWithDependencies>(
                instance);

            Assert.IsType<SimpleConcreteClassOne>(
                instance.ClassOne);
            Assert.IsType<SimpleConcreteClassTwo>(
                instance.ClassTwo);
        }

        [Fact]
        public void ResolveBy_InterfaceType_WithoutDependencies_ReturnsInstance()
        {
            _container.RegisterTransient<
                ISimpleInterface,
                SimpleImplementation>();

            Assert.IsType<SimpleImplementation>(
                _container.Resolve<ISimpleInterface>());
        }

        [Fact]
        public void ResolveBy_InterfaceType_WithDependencies_ReturnsInstance()
        {
            _container.RegisterTransient<
                ISimpleInterface,
                SimpleImplementationWithDependency>();

            var instance = _container.Resolve<ISimpleInterface>();

            Assert.IsType<SimpleImplementationWithDependency>(
                instance);

            Assert.NotNull(
                ((SimpleImplementationWithDependency)instance)
                .ClassOne);
        }
    }
}