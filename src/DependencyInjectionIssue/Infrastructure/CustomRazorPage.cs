using DependencyInjectionIssue.Services;
using DependencyInjectionIssue.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Razor;

namespace DependencyInjectionIssue.Infrastructure
{
    public abstract class CustomRazorPage<TModel> : RazorPage<TModel>
    {
        private readonly ILocalizationService _localizationService;

        private Localizer _localizer;

        /// <summary>
        /// Get a localized resources
        /// </summary>
        public Localizer T
        {
            get
            {
                if (_localizationService is null)
                {
                    //TODO:  how to resolve the dependency in this case
                    // CustomRazorPage<TModel> using @inherits tag and call only an empty constructor
                    // _localizationService = ??

                }

                if (_localizer == null)
                {
                    _localizer = (format, args) =>
                    {
                        var resFormat = _localizationService.GetResource(format);
                        if (string.IsNullOrEmpty(resFormat))
                        {
                            return new LocalizedString(format);
                        }
                        return new LocalizedString((args == null || args.Length == 0)
                            ? resFormat
                            : string.Format(resFormat, args));
                    };
                }
                return _localizer;
            }
        }
    }

    public abstract class CustomRazorPage : RazorPage<dynamic>
    {
    }
}
