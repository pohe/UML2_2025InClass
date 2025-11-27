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
        public int Count { 
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
            foreach(MenuItem m in _menuItemList)
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
            foreach(MenuItem m in _menuItemList)
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
            foreach(MenuItem m in _menuItemList)
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
    }
}
