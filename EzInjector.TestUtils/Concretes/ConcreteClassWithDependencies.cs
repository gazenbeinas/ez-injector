namespace EzInjector.TestUtils.Concretes
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