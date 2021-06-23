using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            AtmStart();
        }
        public static void MoneyWithdrawalDisplay(in Client client, double withdrawnMoney)
        {
            if (client != null)
            {
                if (client.BankAccount.Balance < withdrawnMoney)
                    throw new CardException("There is not enough money on the balance!");
                else
                {
                    client.BankAccount.Balance -= withdrawnMoney;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("The operation was performed successfully!");
                    Operation operation = new($"{withdrawnMoney} AZN was withdrawn from the account!");
                    client.AddOperation(operation);
                    Console.ReadLine();
                }
            }
            else throw new ClientException("Client null!");
        }
        public static void AtmMenu(in Bank kapitalBank)
        {

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Enter pin: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string pin = Console.ReadLine();
                Console.ResetColor();
                if (pin == null) throw new CardException("Pin null!");
                else
                {
                    if (Array.Exists(kapitalBank.Clients, user => user.BankAccount.PIN == pin))
                    {
                        Console.Clear();
                        var client = kapitalBank.GetClientByPin(pin);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Welcome to {client.Name} {client.Surname} ");
                        while (true)
                        {
                            Console.Clear();
                            string[] atmMenu = { "Balance", "Withdrawal", "List of operations performed", "Money transfer", "Back to", "Exit" };
                            for (int i = 0; i < atmMenu.Length; i++)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine($"{i + 1}) {atmMenu[i]}");
                            }
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("\nMake your choise: ");
                            int choise = Convert.ToInt32(Console.ReadLine());
                            if (choise == 1)
                            {
                                Console.Clear();
                                client.BankAccount.ShowBalance();
                                Operation operation = new("The balance was looked at!");
                                client.AddOperation(operation);

                                Console.ReadLine();
                            }
                            else if (choise == 2)
                            {
                                Console.Clear();
                                string[] atmMenu2 = { "10 AZN", "20 AZN", "50 AZN", "100 AZN", "Other" };
                                for (int i = 0; i < atmMenu2.Length; i++)
                                {
                                    Console.WriteLine($"{i + 1}) {atmMenu2[i]}");
                                }
                                Console.Write("\nMake your choise: ");
                                int choise2 = Convert.ToInt32(Console.ReadLine());
                                switch (choise2)
                                {
                                    case 1:
                                        {
                                            double withdrawal = 10;
                                            MoneyWithdrawalDisplay(client, withdrawal);
                                            break;
                                        }
                                    case 2:
                                        {
                                            double withdrawal = 20;
                                            MoneyWithdrawalDisplay(client, withdrawal);
                                            break;
                                        }
                                    case 3:
                                        {
                                            double withdrawal = 50;
                                            MoneyWithdrawalDisplay(client, withdrawal);
                                            break;
                                        }
                                    case 4:
                                        {
                                            double withdrawal = 100;
                                            MoneyWithdrawalDisplay(client, withdrawal);
                                            break;
                                        }
                                    case 5:
                                        {
                                            Console.Write("\nEnter the amount you want to withdraw: ");
                                            double withdrawal = Convert.ToDouble(Console.ReadLine());
                                            MoneyWithdrawalDisplay(client, withdrawal);
                                            break;
                                        }
                                    default:
                                        Console.WriteLine("The choice is wrong!!!");
                                        break;
                                }
                            }
                            else if (choise == 3)
                            {
                                client.ShowAllClientOperations();
                                Console.ReadLine();
                            }
                            else if (choise == 4)
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write("Enter the pin of the card to which you want to transfer money: ");
                                string friendPin = Console.ReadLine();
                                if (friendPin == null) throw new CardException("Pin null!");
                                else if (friendPin == client.BankAccount.PIN) throw new CardException("Same card exception!!!");
                                else
                                {
                                    if (Array.Exists(kapitalBank.Clients, user => user.BankAccount.PIN == friendPin))
                                    {
                                        Console.Clear();
                                        var friend = kapitalBank.GetClientByPin(friendPin);
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        Console.Write("Enter the amount of money you want to transfer: ");
                                        double money = Convert.ToDouble(Console.ReadLine());
                                        if (money > client.BankAccount.Balance)
                                        {
                                            throw new CardException("There is not enough money on the balance!");
                                        }
                                        else
                                        {
                                            client.BankAccount.Balance -= money;
                                            friend.BankAccount.Balance += money;
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("The operation was performed successfully!");
                                            Operation operationClient = new($"{money} AZN was transferred to the account {friend.BankAccount.PAN} !");
                                            Operation operationFriend = new($"{money} AZN came from {client.BankAccount.PAN} account!");
                                            client.AddOperation(operationClient);
                                            friend.AddOperation(operationFriend);
                                            Console.ReadLine();
                                        }
                                    }
                                }
                            }
                            else if (choise == 5) AtmMenu(kapitalBank);
                            else if (choise == 6) Environment.Exit(0);
                            else
                            {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("The choice is wrong!!!");
                                Console.WriteLine("Try again!");
                                Console.ReadLine();
                                Console.ResetColor();
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("No card related to this pin code was found!");
                        Console.WriteLine("Try again!");
                        Console.ReadLine();
                        Console.ResetColor();
                    }
                }
            }
        }
        public static void AtmStart()
        {
            try
            {
                const string bankName = "Kapital bank";
                Card card1 = new(1, bankName, "KANAN IDAYATOV", "4169 0715 7242 1784", "1111", 750.35);
                Card card2 = new(2, bankName, "SAHIL ABDULLAYEV", "4169 0715 1231 3432", "2222", 645.23);
                Card card3 = new(3, bankName, "ELI ELIYEV", "4169 0715 3284 2348", "3333", 1232.23);
                Card card4 = new(4, bankName, "NEBI NEBILI", "4169 0715 1878 6547", "4444", 250.34);
                Card card5 = new(5, bankName, "EMIRASLAN ELIYEV", "4169 0715 8724 2364", "5555", 846.20);

                Client client1 = new(1, "Kenan", "Idayatov", 19, 1500, card1);
                Client client2 = new(2, "Sahil", "Abdullayev", 22, 1250, card2);
                Client client3 = new(3, "Eli", "Eliyev", 24, 850, card3);
                Client client4 = new(4, "Nebi", "Nebili", 19, 2200, card4);
                Client client5 = new(5, "Emiraslan", "Eliyev", 30, 2400, card5);

                Bank kapitalBank = new()
                {
                    Name = "Kapital bank"
                };

                kapitalBank.AddClient(client1);
                kapitalBank.AddClient(client2);
                kapitalBank.AddClient(client3);
                kapitalBank.AddClient(client4);
                kapitalBank.AddClient(client5);

                AtmMenu(kapitalBank);



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

    }
}
