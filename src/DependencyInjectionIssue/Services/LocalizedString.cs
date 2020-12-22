using Microsoft.AspNetCore.Html;

namespace DependencyInjectionIssue.Services
{
    public class LocalizedString : HtmlString
    {
        public LocalizedString(string localized)
            : base(localized)
        {
            Text = localized;
        }

        public string Text { get; }
    }
}
