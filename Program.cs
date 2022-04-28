using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalc
{
    class Program
    {
        static int SelectedOperation { get; set; }
        static List<double>  DataCollector = new List<double>();
        static string Message { get; set; }
        static void Main(string[] args)
        {
            //welcome to kalc
            //this applicaton works as a console calculator
            Intro();
            SelectOperation();
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
                "\n4. Division";
            Console.WriteLine(message);
            
        }
        private static double GetInput(string inputValue, string typeOfInput)
        {
            //Get input and checks out wrong input
            double inputValueD;
            bool validateString;
            switch (typeOfInput)
            {
                case "selectOperation":
                    validateString = double.TryParse(inputValue, out inputValueD);
                    if (validateString == false)
                    {
                    }
                    return inputValueD;
                case "ToDo":
                    if (inputValue.Equals(null) || inputValue.Equals(""))
                    {
                        return 0;
                    }
                    else
                    {

                    }
                        
                    do
                    {
                        string inputedValue = Console.ReadLine();
                        if (inputedValue == )
                        validateString = double.TryParse(inputedValue, out inputValueD);
                        if (validateString == false)
                        {
                            Console.WriteLine("Wrong input, try again> ");
                        }
                    } while (validateString == false);
                    return inputValueD;
            }
            
        }
        static void Validate()
        {
            bool validateString;
            do
            {
                Console.WriteLine("Wrong input, try again> ");
                string selectOperation = Console.ReadLine();
                validateString = double.TryParse(inputValue, out inputValueD);
            } while (validateString == false);
        }
        private static void SelectOperation()
        {
            int selectedOperation;
            do
            {
                Console.Write("Enter a number to select an option> ");
                string selectOperation = Console.ReadLine();
                string typeOfInput = "selectOperation";
                selectedOperation = (int) GetInput(selectOperation, typeOfInput);
                selectedOperation = SelectedOperation;
                if(selectedOperation > 4 || selectedOperation < 1)
                {
                    Console.WriteLine("Invalid Output, Please try again\n");
                }
            } while (selectedOperation > 4 || selectedOperation < 1);

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
                    //To do multiplication operation
                    MultiplicationOperation();
                    break;
                case 4:
                    //To do division operation
                    DivisionOperation();
                    break;
            }
        }
        private static void AdditionOperation()
        {
            Console.WriteLine("Addition in operation");
            //Ask for first input.
            Console.Write("Enter a number to begin addition> ");
            GetInput();
            DataCollector.Add((double)SelectedOperation);
            //Ask for second input.
            Console.Write("Enter another number to continue addition> ");
            GetInput();
            DataCollector.Add((double)SelectedOperation);
            GetRestInput();

        }
        static void GetRestInput() 
        {
            Console.Write("Enter another number or leave blank to exit");
            int inputValue;
            bool validateString;
            do
            {
                string selectOperation = Console.ReadLine();
                validateString = int.TryParse(selectOperation, out selectedOperation);
                if (validateString == false)
                {
                    Console.WriteLine("Wrong input, try again> ");
                }
                else
                {
                    SelectedOperation = selectedOperation;
                }
            } while (validateString == false);

        }
        private static void SubtractionOperation()
        {
            Message = "Subtraction in operation";
        }
        private static void MultiplicationOperation()
        {
            Message = "Multiplication in operation";
        }
        private static void DivisionOperation()
        {
            Message = "Division operation";
        }
    }
}
