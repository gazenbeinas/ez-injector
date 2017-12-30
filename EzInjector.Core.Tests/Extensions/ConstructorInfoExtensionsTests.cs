using System;
using EzInjector.Core.Extensions;
using EzInjector.TestUtils.Concretes;
using Xunit;

namespace EzInjector.Core.Tests.Extensions
{
    public class ConstructorInfoExtensionsTests
    {
        [Theory]
        [InlineData(typeof(SimpleConcreteClassOne))]
        [InlineData(typeof(ConcreteClassWithDependencies), typeof(SimpleConcreteClassOne), typeof(SimpleConcreteClassTwo))]
        public void GetConstructorParametersTypes_ReturnsParameters(
            Type checkingType,
            params Type[] parametersTypes)
        {
            var constructorInfo = checkingType
                .LoadPublicConstructorOf();

            Assert.Equal(
                parametersTypes,
                constructorInfo
                    .GetConstructorParametersTypes());
        }
    }
}
