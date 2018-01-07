using System;
using EzInjector.TestUtils.Interfaces;

namespace EzInjector.TestUtils.Concretes.Implementations
{
    public class SimpleImplementation : ISimpleInterface
    {
        private int Number { get; } = new Random().Next(100);

        public int GenerateNumber() =>
            Number;
    }
}