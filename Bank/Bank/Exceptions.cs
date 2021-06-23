using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class CardException : ApplicationException
    {
        public override string Message { get; }
        public CardException(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Message = message;
        }
    }

    class ClientException : ApplicationException
    {
        public override string Message { get; }
        public ClientException(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Message = message;
        }
    }

}
