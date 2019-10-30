using Common.Localization;
using System;

namespace Common.Helpers
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class MenuItemAttribute : Attribute
    {
        public MenuItemAttribute(string displayName, string navigationUri, string glyph)
        {
            DisplayName = AppResources.ResourceManager.GetString(displayName);
            NavigationUri = navigationUri;
            Glyph = glyph;
        }

        public string DisplayName { get; }

        public string NavigationUri { get; }

        public string Glyph { get; set; }
    }
}
