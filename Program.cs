using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalc
{
    class Program
    {
        static void Main(string[] args)
        {
            //welcome to kalc
            //this applicaton works as a console calculator
            Intro();
            Console.ReadKey();
        }
        
        private static void Intro()
        {
            // Introduces the program
            string message = "Hello, Welcome to Kalc \n " +
                "\nPlease select an operation:" +
                "\n1. Addition" +
                "\n2. Subtraction";
            Console.Write(message);
        }
    }
}
