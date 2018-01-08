using System;
using EzInjector.Core.Resolutions.Services.Abstracts;

namespace EzInjector.Core.Resolutions.Services.Implementations
{
    public class TransientService : LifeStyleService
    {
        public static TransientService Instance = new TransientService();

        public override object Create(
            Type type) =>
            ResolveFor(type);
    }
}