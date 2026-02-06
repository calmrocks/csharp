using System;

namespace GuessGame;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        Console.WriteLine("================================");
        Console.WriteLine("   Welcome to Guess the Number!");
        Console.WriteLine("================================");
        Console.WriteLine();

        while (playAgain)
        {
            PlayGame();
            playAgain = AskPlayAgain();
        }

        Console.WriteLine();
        Console.WriteLine("Thanks for playing! Goodbye!");
    }

    static void PlayGame()
    {
        int playerCount = GetPlayerCount();
        int secretNumber;
        int minNumber = 1;
        int maxNumber = 100;

        if (playerCount == 1)
        {
            // Single player - random number
            Random random = new Random();
            secretNumber = random.Next(minNumber, maxNumber + 1);
            Console.WriteLine();
            Console.WriteLine($"I'm thinking of a number between {minNumber} and {maxNumber}...");
        }
        else
        {
            // Two players - Player 1 sets the number
            secretNumber = GetSecretNumberFromPlayer(minNumber, maxNumber);
        }

        Console.WriteLine();
        
        // Player (or Player 2) guesses
        string guesserName = playerCount == 1 ? "Player" : "Player 2";
        int attempts = PlayGuessingRound(secretNumber, minNumber, maxNumber, guesserName);

        // Show results
        Console.WriteLine();
        Console.WriteLine("================================");
        Console.WriteLine($"🎉 Congratulations! The number was {secretNumber}");
        Console.WriteLine($"   Guessed in {attempts} {(attempts == 1 ? "attempt" : "attempts")}!");
        Console.WriteLine("================================");
    }

    static int GetPlayerCount()
    {
        while (true)
        {
            Console.Write("How many players? (1 or 2): ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int count) && (count == 1 || count == 2))
            {
                return count;
            }

            Console.WriteLine("Please enter 1 or 2.");
        }
    }

    static int GetSecretNumberFromPlayer(int min, int max)
    {
        Console.WriteLine();
        Console.WriteLine("┌─────────────────────────────────────────┐");
        Console.WriteLine("│         PLAYER 1 - SET THE NUMBER       │");
        Console.WriteLine("│   (Player 2, please look away!)         │");
        Console.WriteLine("└─────────────────────────────────────────┘");
        Console.WriteLine();

        int secretNumber;

        while (true)
        {
            Console.Write($"Player 1, enter a number between {min} and {max}: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out secretNumber) && secretNumber >= min && secretNumber <= max)
            {
                break;
            }

            Console.WriteLine($"Please enter a valid number between {min} and {max}.");
        }

        // Clear screen so Player 2 can't see
        Console.WriteLine();
        Console.WriteLine("Press any key to clear screen for Player 2...");
        Console.ReadKey(true);
        Console.Clear();

        Console.WriteLine("================================");
        Console.WriteLine("   Welcome to Guess the Number!");
        Console.WriteLine("================================");
        Console.WriteLine();
        Console.WriteLine("┌─────────────────────────────────────────┐");
        Console.WriteLine("│         PLAYER 2 - YOUR TURN!           │");
        Console.WriteLine("│   Player 1 has set a secret number.     │");
        Console.WriteLine("└─────────────────────────────────────────┘");
        Console.WriteLine();
        Console.WriteLine($"Guess the number between {min} and {max}!");

        return secretNumber;
    }

    static int PlayGuessingRound(int secretNumber, int min, int max, string playerName)
    {
        int attempts = 0;

        while (true)
        {
            Console.Write($"{playerName}, enter your guess: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int guess))
            {
                Console.WriteLine("Please enter a valid number.");
                continue;
            }

            if (guess < min || guess > max)
            {
                Console.WriteLine($"Please enter a number between {min} and {max}.");
                continue;
            }

            attempts++;

            if (guess == secretNumber)
            {
                return attempts;
            }
            else if (guess < secretNumber)
            {
                Console.WriteLine("📈 Too low! Try higher.");
            }
            else
            {
                Console.WriteLine("📉 Too high! Try lower.");
            }
        }
    }

    static bool AskPlayAgain()
    {
        Console.WriteLine();

        while (true)
        {
            Console.Write("Play again? (yes/no): ");
            string? input = Console.ReadLine()?.Trim().ToLower();

            if (input == "yes" || input == "y")
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("   Welcome to Guess the Number!");
                Console.WriteLine("================================");
                Console.WriteLine();
                return true;
            }

            if (input == "no" || input == "n")
            {
                return false;
            }

            Console.WriteLine("Please enter 'yes' or 'no'.");
        }
    }
}