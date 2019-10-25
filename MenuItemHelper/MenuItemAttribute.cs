using System;

namespace MenuItemHelper
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class MenuItemAttribute : Attribute
    {
        public MenuItemAttribute(string displayName, string navigationUri)
        {
            DisplayName = displayName;
            NavigationUri = navigationUri;
        }

        public string DisplayName { get; set; }
        public string NavigationUri { get; set; }
    }
}
