using System;

class GuessingGame
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Guessing Game!");

        int totalGames = 5;
        int player2Score = 0;

        for (int game = 1; game <= totalGames; game++)
        {
            Console.WriteLine($"\nGame {game}");

            // Select level
            int level = SelectLevel();

            // Player 1 sets the word and hint
            string word = SetWord(level);
            string hint = SetHint();

            // Player 2 guesses the word
            int lives = 3;
            bool isCorrect = GuessWord(word, hint, lives);

            // Update scores
            if (isCorrect)
            {
                player2Score += 20;
            }
            else
            {
                Console.WriteLine($"Player 2 couldn't guess the word. The correct word was: {word}");
            }

            // Display scores
            Console.WriteLine($"Player 2 Score: {player2Score}%");
        }

        Console.WriteLine("\nGame Over!");
        Console.WriteLine($"Player 2 total Score was: {player2Score}%");
    }

    static int SelectLevel()
    {
        Console.WriteLine("Select the level :\n Level 1\n Level 2\n Level 3 ");
        int level;
        while (!int.TryParse(Console.ReadLine(), out level) || (level != 1 && level != 2 && level != 3))
        {
            Console.WriteLine("Invalid input. Please enter 3, 4, or 5.");
        }
        return level;
    }

    static string SetWord(int level)
    {
        int length;
        if (level == 1){
            length = 3;
            Console.Write($"Player 1, enter a {length}-letter word: ");
        }
        else if (level == 2){
            length = 4;
            Console.Write($"Player 1, enter a {length}-letter word: ");
        }
        else{
            length = 5;
            Console.Write($"Player 1, enter a {length}-letter word: ");
        }
        string word = Console.ReadLine().ToLower();

        while (word.Length != length)
        {
            Console.WriteLine($"Word length should be {length} characters. Try again.");
            Console.Write($"Player 1, enter a {length}-letter word: ");
            word = Console.ReadLine().ToLower();
        }

        return word;
    }

    static string SetHint()
    {
        Console.Write("Player 1, enter a hint: ");
        return Console.ReadLine();
    }

    static bool GuessWord(string word, string hint, int lives)
    {
        Console.WriteLine($"Hint: {hint}");
        char[] guessedWord = new char[word.Length];

        for (int i = 0; i < word.Length; i++)
        {
            guessedWord[i] = '_';
        }

        while (lives > 0)
        {
            Console.WriteLine($"Word: {string.Join(" ", guessedWord)}");
            Console.WriteLine($"Lives remaining: {lives}");

            Console.Write("Guess the word: ");
            string guess = Console.ReadLine().ToLower();
            Console.WriteLine();

            if (guess == word)
            {
                Console.WriteLine($"Congratulations! You got it: {word}");
                return true;
            }
            else
            {
                Console.WriteLine("Incorrect guess. Try again!");
                lives--;
            }
        }

        Console.WriteLine("Sorry! You ran out of lives.");
        return false;
    }
}
