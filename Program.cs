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
        static char SelectOPerator;
        static int NumberOfRuns=0;
        static double Result;
        static List<double>  DataCollector = new List<double>();
        static string Message;
        static void Main(string[] args)
        {
            //welcome to kalc
            //this applicaton works as a console calculator
            Intro();
            SelectOperation();
            Console.ReadKey();
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
        }
        private static void SelectOperation()
        {
            int selectedOperation;
            Console.Write("Enter a number to select an operation> ");
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
        #region
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
                        Console.WriteLine("Invalid type of input, please try again\n");
                        SelectOperation();
                    }
                    else if (outputValue > 4 || outputValue < 1)
                    {
                        Console.WriteLine("Invalid Output, Please try again\n");
                        SelectOperation();
                    }
                    break;
                case "toDo":
                    if (NumberOfRuns > 1 && (inputValue.Equals(null) || inputValue.Equals("")))
                    {
                        //When user leave blank.
                        outputValue = -1;
                        CollateResult();
                    }
                    else if (validateString == false)
                    {
                        //Collect data again;
                        Console.WriteLine("Wrong input, please put a number");
                        NumberOfRuns--;
                        CollectData(Message, SelectOPerator, out outputValue);
                    }
                    break;
            }
            return outputValue;
        }
        #endregion
        #region
        private static void AdditionOperation()
        {
            SelectOPerator = '+';
            Message = "addition";
            CollectData(Message, SelectOPerator, out double input);
        }
        
        private static void SubtractionOperation()
        {
            //Coming for the first time
            SelectOPerator = '-';
            double input;
            Message = "subtraction";
            CollectData(Message, SelectOPerator, out input);
        }

        private static void MultiplicationOperation()
        {
            //Coming for the first time
            SelectOPerator = '*';
            double input;
            Message = "multiplication";
            CollectData(Message, SelectOPerator, out input);
        }

        private static void DivisionOperation()
        {
            //Coming for the first time
            SelectOPerator = '/';
            double input;
            Message = "division";
            CollectData(Message, SelectOPerator, out input);
        }
        #endregion
        #region
        private static void CollectData(string message, char charOperation, out double input)
        {
            if (NumberOfRuns == 0)
            {
                Console.Write($"Plese enter a number to start the {message}> ");
                NumberOfRuns++;
                input = GetInput(Console.ReadLine(), "toDo");
                CharOperator.Add(charOperation);
                DataCollector.Add(input);
                DoOperation(message, input);
                //To get the second value
                CollectData(Message, SelectOPerator, out input);
            }
            else if (NumberOfRuns == 1)
            {
                Console.Write("Plese enter the second number> ");
                NumberOfRuns++;
                input = GetInput(Console.ReadLine(), "toDo");
                CharOperator.Add(charOperation);
                DataCollector.Add(input);
                DoOperation(message, input);
                SelectOperation();
            }
            else
            {
                Console.Write($"\nPlese enter another number or leave empty to exit (Ans: {Result})> ");
                NumberOfRuns++;
                input = GetInput(Console.ReadLine(), "toDo");
                if (input != -1)
                {
                    CharOperator.Add(charOperation);
                    DataCollector.Add(input);
                    DoOperation(message, input);
                    SelectOperation();
                }
            }
        }
        #endregion
        #region
        private static void DoOperation(string message, double input)
        {
            switch (message)
            {
                case "addition":
                    Result += input;
                    break;
                case "subtraction":
                    Result -= input;
                    break;
                case "multiplcation":
                    Result *= input;
                    break;
                case "division":
                    Result /= input;
                    break;
            }
        }
        private static void CollateResult()
        {
            Console.Write($"Done! {DataCollector[0]}");
            for(int i = 0; i <= DataCollector.Count() - 1; i++)
            {
                Console.Write($" {CharOperator[i]} {DataCollector[i++]}");
            }
            Console.Write($" = {Result}");
        }
        #endregion
    }
}