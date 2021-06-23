using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Bank
    {
        public Client[] Clients { get; set; }
        public string Name { get; set; }

        public void AddClient(in Client newClient)
        {
            int count = (Clients == null) ? 1 : Clients.Length + 1;
            Client[] newClients = new Client[count];
            if (Clients != null) Array.Copy(Clients, newClients, Clients.Length);
            newClients[count - 1] = newClient;
            Clients = newClients;
        }

        public void RemoveClientById(int id)
        {
            if (Array.Exists(Clients, item => item.Id == id))
            {
                int findIndex = Array.FindIndex(Clients, user => user.Id == id);
                if (findIndex >= 0)
                {
                    Client[] newClients = new Client[Clients.Length - 1];
                    if (newClients != null)
                    {
                        Array.Copy(Clients, newClients, findIndex);
                        Array.Copy(Clients, findIndex + 1, newClients, findIndex, Clients.Length - 1 - findIndex);
                    }
                    Clients = newClients;
                }
            }
            else Console.WriteLine("Not find client!");
        }


        public void ShowCardBalance(in Card bankcard)
        {
            if (bankcard == null) throw new CardException("Card is null!");
            else bankcard.ShowBalance();
        }
        public void ShowAllCardsInfo()
        {
            Console.WriteLine("\t\t\tAll cards info");
            foreach (var client in Clients)
            {
                client.BankAccount.ShowCard();
            }
        }
        public void ShowAllClientsInfo()
        {
            Console.WriteLine("\t\t\tAll clients info");
            foreach (var client in Clients)
            {
                client.ShowClientInfo();
            }
        }

        public Client GetClientByPin(string pin)
        {
            if (pin != null)
            {
                if (Array.Exists(Clients, user => user.BankAccount.PIN == pin))
                {
                    return Array.Find(Clients, user => user.BankAccount.PIN == pin);
                }
                else throw new ClientException("Bu pinde olan user yoxdur!");
            }
            else throw new NullReferenceException();
        }
    }
}
