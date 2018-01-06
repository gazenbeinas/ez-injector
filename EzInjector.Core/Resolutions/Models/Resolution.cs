using System;
using EzInjector.Core.Resolutions.Services.Abstracts;
using EzInjector.Core.Resolutions.Services.Implementations;

namespace EzInjector.Core.Resolutions.Models
{
    public abstract class Resolution
    {
        public Type ConcreteType { get; set; }

        public object Initialize() =>
            LifeStyleService.Create(ConcreteType);

        protected LifeStyleService LifeStyleService { get; set; }
    }

    public class SingletonResolution : Resolution
    {
        public SingletonResolution()
        {
            LifeStyleService = SingletonService.Instance;
        }

        public object Instance { get; set; }
    }
}