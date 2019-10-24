using DevAssessment.Helpers;
using DevAssessment.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace DevAssessment.Services
{
    public class MenuService : IMenuService
    {
        public MenuService()
        {
            IEnumerable<MenuItemAttribute> menuItemAttributes = GetType().Assembly.GetCustomAttributes<MenuItemAttribute>();
            var itemList = new List<Item>();
            itemList = menuItemAttributes.Select(x => new Item() { ItemName = x.DisplayName, NavigationUri = x.NavigationUri }).ToList();
            itemList.Add(new Item { ItemName = "Logout", NavigationUri = "LoginPage" });
            Items = new ObservableCollection<Item>(itemList);
        }

        public IEnumerable<Item> Items { get; }
    }
}
