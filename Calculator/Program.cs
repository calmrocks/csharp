using System;

Console.WriteLine("=== Simple Calculator ===");
Console.WriteLine();

// Get first number
Console.Write("Enter first number: ");
double num1 = Convert.ToDouble(Console.ReadLine());

// Get operator
Console.Write("Enter operator (+, -, *, /): ");
string op = Console.ReadLine()!;

// Get second number
Console.Write("Enter second number: ");
double num2 = Convert.ToDouble(Console.ReadLine());

// Calculate and display result
double result;

if (op == "+")
{
    result = num1 + num2;
    Console.WriteLine($"{num1} + {num2} = {result}");
}
else if (op == "-")
{
    result = num1 - num2;
    Console.WriteLine($"{num1} - {num2} = {result}");
}
else if (op == "*")
{
    result = num1 * num2;
    Console.WriteLine($"{num1} * {num2} = {result}");
}
else if (op == "/")
{
    if (num2 != 0)
    {
        result = num1 / num2;
        Console.WriteLine($"{num1} / {num2} = {result}");
    }
    else
    {
        Console.WriteLine("Error: Cannot divide by zero!");
    }
}
else
{
    Console.WriteLine("Unknown operator!");
}