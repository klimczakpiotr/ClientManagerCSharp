using ClientManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManager.App
{
    public class MenuActionService
    {
        public List<MenuAction> MenuActions { get; set; }
        public MenuActionService()
        {
            MenuActions = new List<MenuAction>();
            Initialize();
        }

        private int AddMenu(MenuAction menu)
        {
            MenuActions.Add(menu);
            return menu.Id;
        }

        public void GetMenuActionsByMenuName(string menuName)
        {
            foreach (var menuAction in MenuActions)
            {
                if (menuAction.MenuName == menuName)
                {
                    Console.WriteLine($"{menuAction.Id}. {menuAction.Name}");
                }
            }
        }

        private void Initialize()
        {
            AddMenu(new MenuAction(1, "Add a client", "Main"));
            AddMenu(new MenuAction(2, "Remove a client", "Main"));
            AddMenu(new MenuAction(3, "Show client details", "Main"));
            AddMenu(new MenuAction(4, "List of clients", "Main"));
            AddMenu(new MenuAction(5, "Exit app", "Main"));

            AddMenu(new MenuAction(1, "Individual", "AddNewClientMenu"));
            AddMenu(new MenuAction(2, "Corporate", "AddNewClientMenu"));
            AddMenu(new MenuAction(3, "Noncorporate", "AddNewClientMenu"));
        }
    }
}
