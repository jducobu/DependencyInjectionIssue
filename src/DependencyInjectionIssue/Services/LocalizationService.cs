using DependencyInjectionIssue.Services.Interfaces;

namespace DependencyInjectionIssue.Services
{
    public class LocalizationService : ILocalizationService
    {
        public string GetResource(string resourceKey)
        {
            return "Localized key : {key}";
        }
    }
}
