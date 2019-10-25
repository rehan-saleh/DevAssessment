using DevAssessment.Models;
using Helpers;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace DevAssessment.Services
{
    public class MenuService : IMenuService
    {
        private IModuleCatalog ModuleCatalog { get; set; }

        public MenuService(IModuleCatalog moduleCatalog)
        {
            ModuleCatalog = moduleCatalog;

            LoadMenuItems();
        }

        public IEnumerable<Item> Items { get; set; }

        public void LoadMenuItems()
        {
            List<MenuItemAttribute> menuItemAttributes = GetType().Assembly.GetCustomAttributes<MenuItemAttribute>().ToList();

            var modules = ModuleCatalog.Modules.ToList();
            foreach (var module in modules)
            {
                if (module.State == ModuleState.Initialized)
                {
                    Assembly assembly = Type.GetType(module.ModuleType).Assembly;
                    menuItemAttributes.AddRange(assembly.GetCustomAttributes<MenuItemAttribute>().ToList());
                }
            }

            var itemList = new List<Item>();
            itemList.AddRange(menuItemAttributes.Select(x => new Item() { ItemName = x.DisplayName, NavigationUri = x.NavigationUri }).ToList());
            itemList.Add(new Item { ItemName = "Logout", NavigationUri = "LoginPage" });
            Items = new ObservableCollection<Item>(itemList);
        }

        public void ClearMenuItems()
        {
            Items = new List<Item>();
        }
    }
}
