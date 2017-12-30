using System;
using System.Collections.Generic;
using System.Linq;
using EzInjector.Core.Extensions;

namespace EzInjector.Core
{
    public class Container
    {
        public T ResolveBy<T>()
            where T : class =>
            (T) ResolveBy(typeof(T));

        static object ResolveBy(Type resolvingType)
        {
            var constructor = resolvingType
                .LoadPublicConstructorOf();

            var constructorParametersTypes =
                constructor.GetConstructorParametersTypes();

            if (constructorParametersTypes.Any())
            {
                var parametersInstances =
                    InitializeParameters(
                        constructorParametersTypes);

                return Activator.CreateInstance(
                    resolvingType,
                    parametersInstances.ToArray());
            }

            return Activator.CreateInstance(resolvingType);
        }

        static List<object> InitializeParameters(
            IEnumerable<Type> parametersTypes) =>
            parametersTypes
                .Select(ResolveBy)
                .ToList();
    }
}