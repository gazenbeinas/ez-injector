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

        public class SingletonTests : ContainerTests
        {
            [Fact]
            public void ResolveBy_ConcreteType_SingletonSpecification_ReturnsSingleton()
            {
                _container.RegisterSingleton<
                    MutableConcreteClass>();

                Assert.Equal(0, _container
                    .Resolve<MutableConcreteClass>()
                    .GetValue());

                _container.Resolve<
                        MutableConcreteClass>()
                    .IncreaseValue();

                Assert.Equal(1, _container
                    .Resolve<MutableConcreteClass>()
                    .GetValue());
            }

            [Fact]
            public void ResolveBy_ConcreteType_SingletonSpecification_WithDependencies_ReturnsSingleton()
            {
                _container.RegisterSingleton<
                    MutableConcreteWithDependenciesClass>();

                Assert.Equal(0, _container
                    .Resolve<MutableConcreteWithDependenciesClass>()
                    .GetValue());

                _container.Resolve<
                        MutableConcreteWithDependenciesClass>()
                    .IncreaseValue();

                Assert.Equal(1, _container
                    .Resolve<MutableConcreteWithDependenciesClass>()
                    .GetValue());

                var instance = _container
                    .Resolve<MutableConcreteWithDependenciesClass>();

                Assert.IsType<
                    SimpleConcreteClassOne>(
                    instance.ClassOne);

                Assert.IsType<
                    SimpleConcreteClassTwo>(
                    instance.ClassTwo);
            }
        }

        public class TransientTests : ContainerTests
        {
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
        }
    }
}