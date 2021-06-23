using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Operation
    {
        public string Content { get; }
        public DateTime DateTime { get; }
        public Operation(string content)
        {
            Content = content;
            DateTime = DateTime.Now;
        }


        public void ShowOperation()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(Content);
            Console.WriteLine($"Datetime: {DateTime}");
            Console.WriteLine();
        }
    }
}
