using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalc
{
    class Program
    {
        static List<char> CharOperator = new List<char>();
        static char charOPerator;
        static int NumberOfRuns =0;
        static double Result;
        static List<double>  DataCollector = new List<double>();
        static string Message;
        static void Main(string[] args)
        {
            //welcome to kalc
            //this applicaton works as a console calculator
            Intro();
            //SelectOperation();
            Console.ReadKey();

            //OutPuts
            //Hello, Welcome to Kalc
            //Please select an operation:
            //Enter in a number to select an option
        }
        private static void Intro()
        {
            // Introduces the program.
            string message = "Hello, Welcome to Kalc \n " +
                "\nPlease select an operation:" +
                "\n1. Addition" +
                "\n2. Subtraction" +
                "\n3. Multiplication" +
                "\n4. Division\n";
            Console.WriteLine(message);
            SelectOperation();
        }
        private static void SelectOperation()
        {
            int selectedOperation;
            Console.Write("Enter a number to select an option> ");
            string selectOperation = Console.ReadLine();
            string typeOfInput = "selectOperation";
            selectedOperation = (int)GetInput(selectOperation, typeOfInput);
            switch (selectedOperation)
            {
                case 1:
                    AdditionOperation();
                    break;
                case 2:
                    //To do subtraction operation
                    SubtractionOperation();
                    break;
                case 3:
                    MultiplicationOperation();
                    break;
                case 4:
                    //To do division operation
                    DivisionOperation();
                    break;
            }
        }
        private static void Info(string message)
        {

            Console.WriteLine($"Plese enter number to start the {message}");
        }
        private static double GetInput(string inputValue, string typeOfInput)
        {
            //Get input and checks out wrong input
            bool validateString;
            validateString = double.TryParse(inputValue, out double outputValue);
            switch (typeOfInput)
            {
                case "selectOperation":
                    if (validateString == false)
                    {
                        SelectOperation();
                    }
                    else if (outputValue > 4 || outputValue < 1)
                    {
                        Console.WriteLine("Invalid Output, Please try again\n");
                        SelectOperation();
                    }
                    break;
                case "toDo":
                    if (inputValue.Equals(null) || inputValue.Equals(""))
                    {
                        //When user leave blank.
                        CollateResult();
                    }
                    else if (validateString == false)
                    {
                        //Collect data again;
                        NumberOfRuns =- 1;
                        CollectData(Message, charOPerator, out outputValue);
                    }
                    break;
            }
            return outputValue;
        }
        
        private static void AdditionOperation()
        {
            //Coming for the first time
            charOPerator = '+';
            double input;
            Message = "addition";
            if (NumberOfRuns == 0) { Info(Message); }
            Message = "addition";
            CollectData(Message, charOPerator, out input);
            Result += input;
        }
        
        private static void SubtractionOperation()
        {
            //Coming for the first time
            charOPerator = '-';
            double input;
            Message = "subtraction";
            if (NumberOfRuns == 0) { Info(Message); }
            CollectData(Message, charOPerator, out input);
            Result -= input;
        }
        private static void MultiplicationOperation()
        {
            //Coming for the first time
            charOPerator = '-';
            double input;
            if (NumberOfRuns == 0) { Info(Message); }
            Message = "multiplication";
            CollectData(Message, charOPerator, out input);
            Result *= input;
        }
        private static void DivisionOperation()
        {
            //Coming for the first time
            charOPerator = '-';
            double input;
            Message = "division";
            if (NumberOfRuns == 0) { Info(Message); }
            CollectData(Message, charOPerator, out input);
            Result /=input;
        }
        private static void CollectData(string message, char charOperation, out double input)
        {
            if (NumberOfRuns == 0)
            {
                Console.Write($"Plese enter a number to start {message}> ");
            }
            else if (NumberOfRuns == 1)
            {
                Console.Write("Plese enter another number> ");
            }
            else
            {
                Console.Write($"Plese enter another number or leave empty to exit (Ans: {Result})> ");
            }
            NumberOfRuns = +1;
            input = GetInput(Console.ReadLine(), "toDo");
            CharOperator.Add(charOperation);
            DataCollector.Add(input);
            SelectOperation();
        }
        private static void CollateResult()
        {
            Console.Write($"Done! {DataCollector[0]}");
            for(int i = 0; i <= DataCollector.Count(); i++)
            {
                Console.Write($"{CharOperator[i]} {DataCollector[i++]}");
            }
            Console.Write("-->");
        }
    }
}