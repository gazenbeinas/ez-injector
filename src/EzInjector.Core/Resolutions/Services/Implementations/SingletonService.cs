using System;
using EzInjector.Core.Resolutions.Models;
using EzInjector.Core.Resolutions.Services.Abstracts;

namespace EzInjector.Core.Resolutions.Services.Implementations
{
    public class SingletonService : LifeStyleService
    {
        public static SingletonService Instance =
            new SingletonService();

        public override object Create(Type type)
        {
            var resolution =
                LoadSingletonResolutionFromContainer(type);

            return resolution.Instance ??
                   (resolution.Instance =
                       ResolveFor(type));
        }

        SingletonResolution LoadSingletonResolutionFromContainer(
            Type type) =>
            (SingletonResolution) Container
                .FindByConcreteType(type);
    }
}