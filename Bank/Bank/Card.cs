using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Card
    {
        public int Id { get; set; }
        public string Bankname { get; set; }
        public string Fullname { get; set; }
        public string PAN { get; set; }
        private string pin;
        public string PIN
        {
            get { return pin; }
            set
            {
                if (value.Length == 4)
                    pin = value.Trim();
                else throw new CardException("Pin 4 reqemli ola bilmez!");
            }
        }

        private string cvc;
        public string CVC
        {
            get { return cvc; }
            set
            {
                if (value.Length == 3)
                    cvc = value.Trim();
                else throw new CardException("Cvc 3 reqemli ola bilmez!");
            }
        }
        public double Balance { get; set; }
        public DateTime ExpireDate { get; set; }
        public Card(int id, in string bankname, in string fullname, in string pAN, in string pIN, double balance)
        {
            Id = id;
            Bankname = bankname;
            Fullname = fullname;
            PAN = pAN;
            PIN = pIN;
            CVC = RandomCVC();
            Balance = balance;
            ExpireDate = RandomDate();
        }

        public DateTime RandomDate()
        {
            Random random = new();
            DateTime date = new(random.Next(2022, 2035), random.Next(1, 13), 1);
            return date;

        }

        public string RandomCVC()
        {
            Random random = new();
            int cvc = random.Next(100, 999);
            return cvc.ToString();
        }

        public void ShowCard()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("******** Bankcard Info ********");
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Bank name: {Bankname}");
            Console.WriteLine($"Fullname: {Fullname}");
            Console.WriteLine($"PAN: {PAN}");
            Console.WriteLine($"PIN: {PIN}");
            Console.WriteLine($"CVC: {CVC}");
            Console.WriteLine($"Balance: {Balance}");
            if (ExpireDate.Month >= 1 && ExpireDate.Month <= 9)
                Console.WriteLine($"Expire date: 0{ExpireDate.Month}/{ExpireDate.Year % 100}");
            else
                Console.WriteLine($"Expire date: {ExpireDate.Month}/{ExpireDate.Year % 100}");
            Console.WriteLine();
        }

        public void ShowBalance() => Console.WriteLine($"Card balance: {Balance} ");
    }
}
