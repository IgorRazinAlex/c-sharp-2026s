using System;

public class Calculator
{
    static void ShowHelp()
    {
        Console.WriteLine("╔════════════════════════════╗");
        Console.WriteLine("║         Calculator         ║");
        Console.WriteLine("╠════════════════════════════╣");
        Console.WriteLine("║         q  - exit          ║");
        Console.WriteLine("╚════════════════════════════╝\n");
    }

    bool AskToExit(string input)
    {
        if (input.ToLower() == "q")
        {
            Console.WriteLine("\nExiting...");
            return true;
        }
        return false;
    }

    double GetNumberFromUser()
    {
        while (true)
        {
            Console.Write("Input number: ");
            string input = Console.ReadLine();

            if (AskToExit(input))
            {
                Environment.Exit(0);
            }

            if (double.TryParse(input, out double result))
            {
                return result;
            }

            Console.WriteLine("Error: invalid number\n");
        }
    }

    string GetOperationFromUser()
    {
        while (true)
        {
            Console.Write("Input operation (+, -, *, /): ");
            string operation = Console.ReadLine();

            if (AskToExit(operation))
            {
                Environment.Exit(0);
            }
            
            if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
            {
                return operation;
            }
            
            Console.WriteLine("Unsupported operation\n");
        }
    }
    
    // Функция для выполнения математической операции
    double Calculate(double num1, double num2, string operation)
    {
        switch (operation)
        {
            case "+":
                return num1 + num2;
            case "-":
                return num1 - num2;
            case "*":
                return num1 * num2;
            case "/":
                return num1 / num2;
            default:
                throw new InvalidOperationException("Unknown operation\n");
        }
    }

    void DisplayResult(double num1, double num2, string operation, double result)
    {
        Console.WriteLine("\n" + new string('=', 30));
        Console.Write($"Result: {num1} {operation} {num2} = ");

        if (double.IsNaN(result))
        {
            Console.WriteLine("NaN");
        }
        else if (double.IsPositiveInfinity(result))
        {
            Console.WriteLine("+infty");
        }
        else if (double.IsNegativeInfinity(result))
        {
            Console.WriteLine("-infty");
        }
        else
        {
            Console.WriteLine(result);
        }

        Console.ResetColor();
        Console.WriteLine(new string('=', 30) + "\n");
    }

    void ProcessLoop()
    {
        try
        {
            double num1 = GetNumberFromUser();
            string operation = GetOperationFromUser();
            double num2 = GetNumberFromUser();

            double result = Calculate(num1, num2, operation);

            DisplayResult(num1, num2, operation, result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}\n");
        }
    }

    public static void Main()
    {
        ShowHelp();
        Calculator calculator = new Calculator();

        while (true)
        {
            calculator.ProcessLoop();
        }
    }
}
