using System;
using System.Data;

// Main program loop
bool running = true;

Console.WriteLine("╔═══════════════════════════════════════╗");
Console.WriteLine("║         CALCULATOR                    ║");
Console.WriteLine("╚═══════════════════════════════════════╝");

while (running)
{
    // Ask which mode to use
    int mode = GetMode();

    if (mode == 0)
    {
        running = false;
        continue;
    }

    // Run selected calculator
    if (mode == 1)
    {
        RunStepByStepCalculator();
    }
    else
    {
        RunFreeFormCalculator();
    }

    // Ask to continue
    if (!AskContinue())
    {
        running = false;
    }
}

Console.WriteLine();
Console.WriteLine("Thanks for using Calculator! Goodbye!");


// ============================================
// Mode Selection
// ============================================
int GetMode()
{
    Console.WriteLine();
    Console.WriteLine("Choose calculator mode:");
    Console.WriteLine("  1. Step-by-step (choose operation, then enter numbers)");
    Console.WriteLine("  2. Free-form (type expression like 4+6*12)");
    Console.WriteLine("  0. Exit");
    Console.WriteLine();

    while (true)
    {
        Console.Write("Enter choice (0-2): ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int choice) && choice >= 0 && choice <= 2)
        {
            return choice;
        }

        Console.WriteLine("Please enter 0, 1, or 2.");
    }
}


// ============================================
// Mode 1: Step-by-Step Calculator
// ============================================
void RunStepByStepCalculator()
{
    Console.WriteLine();
    Console.WriteLine("┌─────────────────────────────────────┐");
    Console.WriteLine("│     STEP-BY-STEP CALCULATOR         │");
    Console.WriteLine("└─────────────────────────────────────┘");
    Console.WriteLine();

    // Step 1: Choose operation
    char operation = GetOperation();

    // Step 2: Get numbers
    double num1 = GetNumber("Enter first number: ");
    double num2 = GetNumber("Enter second number: ");

    // Step 3: Calculate
    double? result = Calculate(num1, num2, operation);

    // Step 4: Display result
    if (result.HasValue)
    {
        Console.WriteLine();
        Console.WriteLine($"  {num1} {operation} {num2} = {result.Value}");
    }
}

char GetOperation()
{
    Console.WriteLine("Choose operation:");
    Console.WriteLine("  + : Add");
    Console.WriteLine("  - : Subtract");
    Console.WriteLine("  * : Multiply");
    Console.WriteLine("  / : Divide");
    Console.WriteLine("  % : Modulus");
    Console.WriteLine();

    char[] validOps = { '+', '-', '*', '/', '%' };

    while (true)
    {
        Console.Write("Enter operation: ");
        string? input = Console.ReadLine()?.Trim();

        if (!string.IsNullOrEmpty(input) && input.Length == 1)
        {
            char op = input[0];
            if (Array.Exists(validOps, x => x == op))
            {
                Console.WriteLine();
                return op;
            }
        }

        Console.WriteLine("Please enter +, -, *, /, or %");
    }
}

double GetNumber(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();

        if (double.TryParse(input, out double number))
        {
            return number;
        }

        Console.WriteLine("Invalid number. Please try again.");
    }
}

double? Calculate(double a, double b, char operation)
{
    switch (operation)
    {
        case '+':
            return a + b;

        case '-':
            return a - b;

        case '*':
            return a * b;

        case '/':
            if (b == 0)
            {
                Console.WriteLine();
                Console.WriteLine("  Error: Cannot divide by zero!");
                return null;
            }
            return a / b;

        case '%':
            return a % b;

        default:
            Console.WriteLine();
            Console.WriteLine("  Error: Unknown operation!");
            return null;
    }
}


// ============================================
// Mode 2: Free-Form Calculator
// ============================================
void RunFreeFormCalculator()
{
    Console.WriteLine();
    Console.WriteLine("┌─────────────────────────────────────┐");
    Console.WriteLine("│       FREE-FORM CALCULATOR          │");
    Console.WriteLine("└─────────────────────────────────────┘");
    Console.WriteLine();
    Console.WriteLine("Enter expressions like:");
    Console.WriteLine("  4+6*12");
    Console.WriteLine("  (10+5)*2");
    Console.WriteLine("  100/4-3+2*5");
    Console.WriteLine();
    Console.WriteLine("Type 'done' to finish free-form mode");
    Console.WriteLine();

    var table = new DataTable();
    bool inFreeForm = true;

    while (inFreeForm)
    {
        Console.Write("> ");
        string? input = Console.ReadLine()?.Trim();

        // Empty input - skip
        if (string.IsNullOrEmpty(input))
        {
            continue;
        }

        // Exit free-form mode
        if (input.ToLower() == "done" || input.ToLower() == "d")
        {
            inFreeForm = false;
            continue;
        }

        // Calculate expression
        try
        {
            // Replace common multiplication symbols
            string expression = input
                .Replace("x", "*")
                .Replace("X", "*")
                .Replace("×", "*")
                .Replace("÷", "/");

            var result = table.Compute(expression, "");
            Console.WriteLine($"  = {result}");
        }
        catch (Exception)
        {
            Console.WriteLine("  Error: Invalid expression. Try again.");
        }

        Console.WriteLine();
    }
}


// ============================================
// Continue Prompt
// ============================================
bool AskContinue()
{
    Console.WriteLine();
    Console.WriteLine("────────────────────────────────────────");

    while (true)
    {
        Console.Write("Would you like to do another calculation? (yes/no): ");
        string? input = Console.ReadLine()?.Trim().ToLower();

        if (input == "yes" || input == "y")
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════╗");
            Console.WriteLine("║         CALCULATOR                    ║");
            Console.WriteLine("╚═══════════════════════════════════════╝");
            return true;
        }

        if (input == "no" || input == "n")
        {
            return false;
        }

        Console.WriteLine("Please enter 'yes' or 'no'.");
    }
}