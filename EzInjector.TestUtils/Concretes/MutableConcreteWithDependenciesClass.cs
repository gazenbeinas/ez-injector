namespace EzInjector.TestUtils.Concretes
{
    public class MutableConcreteWithDependenciesClass
    {
        public readonly SimpleConcreteClassOne ClassOne;
        public readonly SimpleConcreteClassTwo ClassTwo;

        private int _value;

        public MutableConcreteWithDependenciesClass(
            SimpleConcreteClassOne classOne,
            SimpleConcreteClassTwo classTwo)
        {
            ClassOne = classOne;
            ClassTwo = classTwo;
        }

        public void IncreaseValue() => _value++;
        public int GetValue() => _value;
    }
}