using System;

namespace Helpers
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class MenuItemAttribute : Attribute
    {
        public MenuItemAttribute(string displayName, string navigationUri)
        {
            DisplayName = displayName;
            NavigationUri = navigationUri;
        }

        public string DisplayName { get; }

        public string NavigationUri { get; }
    }
}
