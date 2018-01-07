using EzInjector.Core.Resolutions.Models.Abstracts;
using EzInjector.Core.Resolutions.Services.Implementations;

namespace EzInjector.Core.Resolutions.Models
{
    public class TransientResolution : Resolution
    {
        public TransientResolution() =>
            LifeStyleService = TransientService.Instance;
    }
}