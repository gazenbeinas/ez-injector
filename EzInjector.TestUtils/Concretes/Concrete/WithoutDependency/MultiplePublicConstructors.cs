namespace EzInjector.TestUtils.Concretes.Concrete.WithoutDependency
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