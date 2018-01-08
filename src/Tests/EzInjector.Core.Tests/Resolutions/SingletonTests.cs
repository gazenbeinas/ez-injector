using EzInjector.TestUtils.Concretes.Concrete.WithoutDependency;
using EzInjector.TestUtils.Concretes.Implementations;
using EzInjector.TestUtils.Concretes.Mutables;
using EzInjector.TestUtils.Interfaces;
using Xunit;

namespace EzInjector.Core.Tests.Resolutions
{
    public class SingletonTests
    {
        readonly Container _container;

        public SingletonTests()
        {
            _container = new Container();
        }

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

        [Fact]
        public void ResolveBy_InterfaceType_WithoutDependencies_ReturnsInstance()
        {
            _container.RegisterSingleton<
                ISimpleInterface,
                SimpleImplementation>();

            var instanceOne = _container.Resolve<ISimpleInterface>();
            Assert.IsType<SimpleImplementation>(instanceOne);

            var instanceTwo = _container.Resolve<ISimpleInterface>();
            Assert.IsType<SimpleImplementation>(instanceTwo);

            Assert.Equal(instanceOne, instanceTwo);
            Assert.Equal(
                instanceOne.GenerateNumber(),
                instanceTwo.GenerateNumber());
        }

        [Fact]
        public void ResolveBy_InterfaceType_WithDependencies_ReturnsInstance()
        {
            _container.RegisterSingleton<
                ISimpleInterface,
                SimpleImplementationWithDependency>();

            var instanceOne = _container.Resolve<ISimpleInterface>();
            Assert.IsType<SimpleImplementationWithDependency>(instanceOne);

            var instanceTwo = _container.Resolve<ISimpleInterface>();
            Assert.IsType<SimpleImplementationWithDependency>(
                instanceTwo);

            Assert.Equal(instanceOne, instanceTwo);
            Assert.Equal(
                instanceOne.GenerateNumber(),
                instanceTwo.GenerateNumber());

            Assert.NotNull(
                ((SimpleImplementationWithDependency)instanceOne)
                .ClassOne);
        }
    }
}