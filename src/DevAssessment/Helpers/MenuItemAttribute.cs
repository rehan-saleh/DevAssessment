using System;

namespace DevAssessment.Helpers
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    internal sealed class MenuItemAttribute : Attribute
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
