using ClientManager.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientManager.App
{
    public class ClientService
    {
        public List<Client> Clients { get; set; }

        public ClientService()
        {
            Clients = new List<Client>();
        }

        public ConsoleKeyInfo AddNewClientView(MenuActionService menuActionService)
        {
            Console.WriteLine("\r\nPlease select client type: ");
            menuActionService.GetMenuActionsByMenuName("AddNewClientMenu");

            var operation = Console.ReadKey(true);
            return operation;
        }

        public int AddNewClient(char clientType)
        {
            int clientTypeId;
            int.TryParse(clientType.ToString(), out clientTypeId);
            Client client = new Client();
            client.TypeId = clientTypeId;
            client.Id = Clients.Count() + 1;
            Console.WriteLine("Please enter name for new client:");
            client.Name = Console.ReadLine();
            if (clientTypeId == 1)
            {
                Console.WriteLine("Please enter PESEL for new client:");
                int pesel;
                int.TryParse(Console.ReadLine(), out pesel);
                client.PESEL = pesel;
            }
            else
            {
                Console.WriteLine("Please enter NIP for new client:");
                int nip;
                int.TryParse(Console.ReadLine(), out nip);
                client.PESEL = nip;
            }

            Clients.Add(client);
            return client.Id;
        }

        public int RemoveClientView()
        {
            Console.WriteLine("\r\nPlease enter id for client you want to remove:");
            var clientId = Console.ReadKey();
            int id;
            int.TryParse(clientId.KeyChar.ToString(), out id);

            return id;
        }

        public void RemoveClient(int removeId)
        {
            Client clientToRemove = new Client();
            foreach (var client in Clients)
            {
                if (client.Id == removeId)
                {
                    clientToRemove = client;
                    break;
                }
            }
            Clients.Remove(clientToRemove);
        }

        public void ClientDetailView()
        {
            Console.WriteLine("\r\nPlease enter id for client you want to show:");
            var clientId = Console.ReadKey();
            int id;
            int.TryParse(clientId.KeyChar.ToString(), out id);

            Client clientToShow = Clients.FirstOrDefault(p => p.Id == id);

            Console.WriteLine($"Client id: {clientToShow.Id}");
            Console.WriteLine($"Client name: {clientToShow.Name}");
            Console.WriteLine($"Client type id: {clientToShow.TypeId}");
            Console.WriteLine($"Client PESEL: {clientToShow.PESEL}");
            Console.WriteLine($"Client NIP: {clientToShow.NIP}");
        }
        public int ClientTypeSelectionView()
        {
            Console.WriteLine("\r\nPlease enter type id for client type you want to show (or 0 for all clients):");
            var typeId = Console.ReadKey();
            int id;
            int.TryParse(typeId.KeyChar.ToString(), out id);

            return id;
        }

        public void ClientsByTypeIdView(int typeId)
        {
            List<Client> clientsByTypeId = new List<Client>();
            if (Clients.Count > 0)
            {
                Console.WriteLine("\r\nId\t|" + "Name\t|" + "TypeId\t|" +  "PESEL\t|NIP");
                foreach (var client in Clients)
                {
                    if (client.TypeId == typeId || typeId == 0)
                    {
                        clientsByTypeId.Add(client);
                        Console.WriteLine(client.Id + "\t|" + client.Name + "\t|" + client.TypeId + "\t|" + client.PESEL + "\t|" + client.NIP);
                    }
                }
            }
            
        }
    }
}
