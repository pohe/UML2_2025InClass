using PizzaLibrary.Data;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaLibrary.Services
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private List<MenuItem> _menuItemList;
        public int Count
        {
            get { return _menuItemList.Count; }
        }

        public MenuItemRepository()
        {
            _menuItemList = MockData.MenuItemData;

        }

        public void AddMenuItem(MenuItem menuItem)
        {
            if (!MenuItemNameExist(menuItem.Name))
            {
                _menuItemList.Add(menuItem);
            }

        }
        private bool MenuItemNameExist(string name)
        {
            foreach (MenuItem m in _menuItemList)
            {
                if (m.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public List<MenuItem> GetAll()
        {
            //List<MenuItem> returMenu = new List<MenuItem>();
            //foreach(MenuItem m in _menuItemList)
            //{
            //    returMenu.Add(m);
            //}
            //return returMenu;
            return _menuItemList;
        }

        public MenuItem GetMenuItemByNo(int no)
        {
            foreach (MenuItem m in _menuItemList)
            {
                if (m.No == no)
                {
                    return m;
                }
            }
            return null;
        }

        public void PrintAllMenuItems()
        {
            foreach (MenuItem m in _menuItemList)
            {
                Console.WriteLine(m);
            }
        }

        public void RemoveMenuItem(int no)
        {
            //for(int i = 0; i<_menuItemList.Count; i++)
            //{
            //    if (_menuItemList[i].No == no )
            //    {
            //        _menuItemList.RemoveAt(i);
            //        return;
            //    }
            //}
            //alternativt
            //for (int i = 0; i < _menuItemList.Count; i++)
            //{
            //    if (_menuItemList[i].No == no)
            //    {
            //        _menuItemList.Remove(_menuItemList[i]);
            //        return;
            //    }
            //}
            //Alternativt:
            MenuItem mTOBeRemoved = GetMenuItemByNo(no);
            if (mTOBeRemoved != null)
            {
                _menuItemList.Remove(mTOBeRemoved);
            }
            //else
            //    return; 

        }

        public List<MenuItem> GetMenuType(MenuType type)
        {
            List<MenuItem> menuTypes = new List<MenuItem>();
            foreach (MenuItem mt in _menuItemList)
            {
                if (mt.TheMenuType == type)
                {
                    menuTypes.Add(mt);
                }
            }
            return menuTypes;
        }


        public MenuItem? FindMostExpensiveMenuItem(MenuType mt)
        {
            List<MenuItem> list = GetMenuType(mt);
            if (list != null && list.Count > 0)
            {
                MenuItem mostExpensive = list[0];
                foreach (MenuItem mi in list)
                {
                    if (mi.Price > mostExpensive.Price)
                    {
                        mostExpensive = mi;
                    }
                }
                return mostExpensive;
            }
            return null;
        }


        public MenuItem? GetMostExpensivePizza()
        {
            MenuItem menuItem = null;
            foreach (MenuItem m in _menuItemList)
            {
                if (m.TheMenuType == MenuType.PIZZECLASSSICHE || m.TheMenuType == MenuType.PIZZESPECIALI)
                {
                    if (menuItem == null || m.Price > menuItem.Price)
                    {
                        menuItem = m;
                    }
                }
            }
            return menuItem;
        }

        public MenuItem MostExpensivePizza()
        {
            MenuItem? mostExpensivePizza = null;
            MenuItem expensiveClassicPizza = FindMostExpensiveMenuItem(MenuType.PIZZECLASSSICHE);
            MenuItem expensiveSpeciallePizza = FindMostExpensiveMenuItem(MenuType.PIZZESPECIALI);

            if (expensiveClassicPizza != null && expensiveSpeciallePizza != null)
            {
                if (expensiveClassicPizza.Price >= expensiveSpeciallePizza.Price)
                {
                    mostExpensivePizza = expensiveClassicPizza;
                }
                else
                {
                    mostExpensivePizza = expensiveSpeciallePizza;
                }
            }
            else if (expensiveClassicPizza == null)
            {
                mostExpensivePizza = expensiveSpeciallePizza;
            }
            else
            {
                mostExpensivePizza = expensiveClassicPizza;
            }
            return mostExpensivePizza;
        }

        public void PrintMenuCard()
        {
            // Iterate over all values of the enum and print the items for each MenuType
            foreach (MenuType mtype in Enum.GetValues(typeof(MenuType)))
            {
                Console.WriteLine($"--- {mtype} ---");
                List<MenuItem> items = GetMenuType(mtype);
                if (items.Count == 0)
                {
                    Console.WriteLine("  (no items)");
                    continue;
                }

                foreach (var item in items)
                {
                    // Use the MenuItem properties you have available
                    Console.WriteLine($"  {item.No}: {item.Name} - {item.Price:C} - {item.Description}");
                }
            }

        }
    }
}
