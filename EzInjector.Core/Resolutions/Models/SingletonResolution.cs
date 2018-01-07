using EzInjector.Core.Resolutions.Models.Abstracts;
using EzInjector.Core.Resolutions.Services.Implementations;

namespace EzInjector.Core.Resolutions.Models
{
    public class SingletonResolution : Resolution
    {
        public SingletonResolution() =>
            LifeStyleService = SingletonService.Instance;

        public object Instance { get; set; }
    }
}