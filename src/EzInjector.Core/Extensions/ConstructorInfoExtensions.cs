using System;
using System.Linq;
using System.Reflection;

namespace EzInjector.Core.Extensions
{
    public static class ConstructorInfoExtensions
    {
        public static Type[] GetConstructorParametersTypes(
            this ConstructorInfo constructorInfo) =>
            constructorInfo
                .GetParameters()
                .Select(p => p.ParameterType)
                .ToArray();
    }
}