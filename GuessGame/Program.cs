using System;

class Program
{
    static void Main()
    {
        int minRange = 1;
        int maxRange = 100;
        
        // ===== Player 1: Set the secret number =====
        int secretNumber;


        
        
        while (true)
        {
            Console.Write($"Player 1, enter a number ({minRange}-{maxRange}): ");
            string input = Console.ReadLine();
            
            // Validation 1: Check if it's a valid number
            if (!int.TryParse(input, out secretNumber))
            {
                Console.WriteLine("Error: Please enter a valid number!");
                continue;
            }
            
            // Validation 2: Check if it's in range
            if (secretNumber < minRange || secretNumber > maxRange)
            {
                Console.WriteLine($"Error: Number must be between {minRange} and {maxRange}!");
                continue;
            }
            
            // Valid input, break the loop
            break;
        }
        
        // Clear screen to hide the number
        Console.Clear();
        
        // ===== Player 2: Guess the number =====
        Console.WriteLine("========================================");
        Console.WriteLine("   Player 2, start guessing!");
        Console.WriteLine($"   Range: {minRange} - {maxRange}");
        Console.WriteLine("========================================");
        Console.WriteLine();
        
        int guess;
        int attempts = 0;
        
        while (true)
        {
            Console.Write("Your guess: ");
            string input = Console.ReadLine();
            
            // Validation 1: Check if it's a valid number
            if (!int.TryParse(input, out guess))
            {
                Console.WriteLine("Error: Please enter a valid number!");
                continue;
            }
            
            // Validation 2: Check if it's in range
            if (guess < minRange || guess > maxRange)
            {
                Console.WriteLine($"Error: Please guess a number between {minRange} and {maxRange}!");
                continue;
            }
            
            // Valid guess, count the attempt
            attempts++;

            // Check the guess
            if (guess > secretNumber)
            {
                Console.WriteLine("Too high! \nTry again.");

            }
            else if (guess < secretNumber)
            {
                Console.WriteLine("Too low! \nTry again.");
            }
            else
            {
                // Correct guess!
                break;
            }
            
            Console.WriteLine();
        }
        
        // ===== Game Over =====
        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine($"  Congratulations! You got it!");
        Console.WriteLine($"  The number was: {secretNumber}");
        Console.WriteLine($"  Attempts: {attempts}");
        Console.WriteLine("========================================");
    }
}