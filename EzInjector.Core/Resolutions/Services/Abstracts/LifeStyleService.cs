using System;
using System.Collections.Generic;
using System.Linq;
using EzInjector.Core.Extensions;

namespace EzInjector.Core.Resolutions.Services.Abstracts
{
    public abstract class LifeStyleService
    {
        protected Container Container =
            Container.Instance;

        public abstract object Create(
            Type type);

        protected object ResolveFor(Type resolvingType)
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

        object[] InitializeParameters(
            IEnumerable<Type> parametersTypes) =>
            parametersTypes
                .Select(p => Container.Resolve(p))
                .ToArray();
    }
}