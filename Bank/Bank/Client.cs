using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public double Salary { get; set; }
        public Card BankAccount { get; set; }
        public Operation[]  Operations { get; set; }
        public Client(int ıd, in string name, in string surname, int age, double salary, Card bankAccount)
        {
            Id = ıd;
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            this.BankAccount = bankAccount;
        }
        public void ShowClientInfo()
        {
            Console.WriteLine("******** User Info ********");
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Salary: {Salary}");
            Console.WriteLine();
        }
        public void AddOperation(in Operation newOperation)
        {
            int count = (Operations == null) ? 1 : Operations.Length + 1;
            Operation[] newOperations = new Operation[count];
            if (Operations != null) Array.Copy(Operations, newOperations, Operations.Length);
            newOperations[count - 1] = newOperation;
            Operations = newOperations;
        }

        public void ShowAllClientOperations()
        {
            Console.Clear();
            if (Operations.Length == 0) Console.WriteLine("There is no operation.");
            else
            {
                foreach (var op in Operations)
                {
                    op.ShowOperation();
                }
            }
        }
    }
}
