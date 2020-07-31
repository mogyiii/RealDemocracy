using Microsoft.Extensions.Localization;
using System.Reflection;
using Dec.Web.SharedResource;

namespace Dec.Web.Services
{
    public class LocalizationService
    {
        private readonly IStringLocalizer _localizer;

        public LocalizationService(IStringLocalizerFactory localizerFactory)
        {
            var type = typeof(SharedResourceDummy);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = localizerFactory.Create("SharedResource", assemblyName.Name);
        }

        public LocalizedString GetLocalizedString(string key)
        {
            return _localizer[key];
        }
    }
}
