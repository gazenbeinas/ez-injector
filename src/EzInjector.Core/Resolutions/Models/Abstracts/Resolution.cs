using System;
using EzInjector.Core.Resolutions.Services.Abstracts;

namespace EzInjector.Core.Resolutions.Models.Abstracts
{
    public abstract class Resolution
    {
        public Type AbstractType { get; set; }
        public Type ConcreteType { get; set; }

        public object Initialize() =>
            LifeStyleService.Create(ConcreteType);

        protected LifeStyleService LifeStyleService { get; set; }
    }
}