using System;
using static System.Console;
class GuessAWord
{
    static void Main()
    {
        string[] words = {"apricot", "elephant", "tigress",
         "fortunate", "impossible", "historical",
         "colorful", "science"};
        Random RandomClass = new Random();
        int randomNumber;
        randomNumber = RandomClass.Next(0, words.Length);
        string selectedWord = words[randomNumber];
        string guessedWord = "";
        string originalWord = selectedWord;
        string guess;
        char letter;
        int pos;
        char tempChar;
        int foundCount = 0;
        bool letterInWord;
        for (int a = 0; a < selectedWord.Length; ++a)
            guessedWord = guessedWord + "*";
        while (foundCount < selectedWord.Length)
        {
            WriteLine("Word: {0}", guessedWord);
            Write("Guess a letter >> ");
            guess = ReadLine();

            while (string.IsNullOrEmpty(guess) || !char.IsLetter(guess[0]))
            {
                try
                {
                    throw new NonLetterException(guess);
                }

                catch (NonLetterException error)
                {
                    Console.WriteLine(error.Message);
                }

                WriteLine("Word: {0}", guessedWord);
                Write("Guess a letter >> ");
                guess = Console.ReadLine();
            }
            letter = Convert.ToChar(guess.Substring(0, 1));


            
            letterInWord = false;
            for (pos = 0; pos < selectedWord.Length; ++pos)
            {
                tempChar = Convert.ToChar(selectedWord.Substring(pos, 1));
                if (tempChar == letter)
                {
                    guessedWord = guessedWord.Substring(0, pos) + letter + guessedWord.Substring(pos + 1, (guessedWord.Length - 1 - pos));
                    selectedWord = selectedWord.Substring(0, pos) + '?' + selectedWord.Substring(pos + 1, (guessedWord.Length - 1 - pos));
                    ++foundCount;
                    letterInWord = true;
                }

            }
            if (letterInWord)
                WriteLine("Yes! {0} is in the word", letter);
            else
                WriteLine("Sorry. {0} is not in the word", letter);
        }
        WriteLine("Good job! Word was {0}", originalWord);
    }

    class NonLetterException : Exception
    {
        public NonLetterException(string message) : base($"'{message}' is not a letter. Please enter an actual letter.")
        {

        }
    }

}
