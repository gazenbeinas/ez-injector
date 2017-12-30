using EzInjector.TestUtils.Concretes;
using Xunit;

namespace EzInjector.Core.Tests
{
    public class ContainerTests
    {
        readonly Container _container;

        public ContainerTests()
        {
            _container = new Container();
        }

        [Fact]
        public void ResolveBy_ConcreteType_WithoutDependencies_ReturnsInstance()
        {
            Assert.IsType<SimpleConcreteClassOne>(
                _container.ResolveBy<SimpleConcreteClassOne>());
        }

        [Fact]
        public void ResolveBy_ConcreteType_WithDependencies_ReturnsInstance()
        {
            var instance = _container
                .ResolveBy<ConcreteClassWithDependencies>();

            Assert.IsType<ConcreteClassWithDependencies>(
                instance);

            Assert.IsType<SimpleConcreteClassOne>(
                instance.ClassOne);
            Assert.IsType<SimpleConcreteClassTwo>(
                instance.ClassTwo);
        }
    }
}