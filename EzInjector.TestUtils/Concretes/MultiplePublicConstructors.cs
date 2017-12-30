namespace EzInjector.TestUtils.Concretes
{
    public class MultiplePublicConstructors
    {
        public readonly SimpleConcreteClassOne Parameter;

        public MultiplePublicConstructors(
            SimpleConcreteClassOne parameter)
        {
            Parameter = parameter;
        }

        public MultiplePublicConstructors()
        {
        }
    }
}
