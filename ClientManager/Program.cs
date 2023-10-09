using ClientManager.App;
using ClientManager.Domain.Entity;
using System;

namespace ClientManager
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService menuActionService = new MenuActionService();
            ClientService clientService = new ClientService();

            Console.WriteLine("Welcome to Client Manager!");
            bool terminate = false;
            while (!terminate)
            {
                Console.WriteLine("\r\nPlease let me know what you want to do:");
                menuActionService.GetMenuActionsByMenuName("Main");

                var operation = Console.ReadKey();
                switch (operation.KeyChar)
                {
                    case '1':
                        var keyInfo = clientService.AddNewClientView(menuActionService);
                        var id = clientService.AddNewClient(keyInfo.KeyChar);
                        Console.WriteLine(id);
                        break;
                    case '2':
                        var removeId = clientService.RemoveClientView();
                        clientService.RemoveClient(removeId);
                        break;
                    case '3':
                        clientService.ClientDetailView();
                        break;
                    case '4':
                        var typeId = clientService.ClientTypeSelectionView();
                        clientService.ClientsByTypeIdView(typeId);
                        break;
                    case '5':
                        terminate = true;
                        break;
                    default:
                        Console.WriteLine("\r\nAction you entered does not exist. Please choose a valid option.");
                        break;
                }
            }

        }

    }
}