using EzInjector.Core.Exceptions;
using EzInjector.Core.Extensions;
using EzInjector.TestUtils.Concretes;
using EzInjector.TestUtils.Concretes.Concrete.WithoutDependency;
using Xunit;

namespace EzInjector.Core.Tests.Extensions
{
    public class TypeExtensionsTests
    {
        [Fact]
        public void LoadPublicConstructorOf_MultiplePublicConstructors_ThrowsException()
        {
            var exception = Assert.Throws<PublicConstructorException>(() =>
                typeof(MultiplePublicConstructors).LoadPublicConstructorOf());

            Assert.Equal(
                $"{nameof(MultiplePublicConstructors)} cannot have more than a single public constructor",
                exception.Message);
        }
    }
}