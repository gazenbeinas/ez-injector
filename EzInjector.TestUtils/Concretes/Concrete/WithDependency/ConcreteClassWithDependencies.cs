using EzInjector.TestUtils.Concretes.Concrete.WithoutDependency;

namespace EzInjector.TestUtils.Concretes.Concrete.WithDependency
{
    public class ConcreteClassWithDependencies
    {
        public readonly SimpleConcreteClassOne ClassOne;
        public readonly SimpleConcreteClassTwo ClassTwo;

        public ConcreteClassWithDependencies(
            SimpleConcreteClassOne classOne,
            SimpleConcreteClassTwo classTwo)
        {
            ClassOne = classOne;
            ClassTwo = classTwo;
        }
    }
}