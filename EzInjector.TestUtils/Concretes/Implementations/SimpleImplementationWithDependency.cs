using System;
using EzInjector.TestUtils.Concretes.Concrete.WithoutDependency;
using EzInjector.TestUtils.Interfaces;

namespace EzInjector.TestUtils.Concretes.Implementations
{
    public class SimpleImplementationWithDependency : ISimpleInterface
    {
        public readonly SimpleConcreteClassOne ClassOne;

        public SimpleImplementationWithDependency(
            SimpleConcreteClassOne classOne)
        {
            ClassOne = classOne;
        }

        private int Number { get; } = new Random().Next(100);

        public int GenerateNumber() =>
            Number;
    }
}