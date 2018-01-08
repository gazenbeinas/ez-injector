using System;
using System.Linq;
using System.Reflection;
using EzInjector.Core.Exceptions;

namespace EzInjector.Core.Extensions
{
    public static class TypeExtensions
    {
        public static ConstructorInfo LoadPublicConstructorOf(this Type type)
        {
            var publicConstructors = type
                .GetConstructors()
                .Where(x => x.IsPublic)
                .ToArray();

            if (publicConstructors.Length > 1)
                throw new PublicConstructorException(type);

            return publicConstructors.Single();
        }
    }
}