using System;
using System.Text;

namespace HW_1_3;

/// <summary>
/// Startup class.
/// </summary>
internal class Program
{
    /// <summary>
    /// Entry point.
    /// </summary>
    /// <param name="args">Array of strings.</param>
    private static void Main(string[] args)
    {
        Console.WriteLine("Please enter at least 5 words (separated by spaces):");

        var userInput = Console.ReadLine() ?? string.Empty;
        Console.WriteLine();

        Console.WriteLine("Here is the new string with replaced first and last letter of each word:");

        var result = ReplaceFirstAndLastLetters(userInput);
        Console.WriteLine(result);
        Console.WriteLine();

        Console.WriteLine("If a word started with the letter 'P' or 'p' it was replaced with 'S'.");
        Console.WriteLine("If a word ended with the letter 'N' or 'n' it was replaced with 'O'.");

        Console.ReadKey();
    }

    /// <summary>
    /// This method replaces every first and last letters of each word with the other letters ("P" replaces with "S" and "N" replaces with "O").
    /// </summary>
    /// <param name="input">Any string to replace letters.</param>
    /// <returns>A new string with replaced the first and the last letter of each word.</returns>
    private static string ReplaceFirstAndLastLetters(string input)
    {
        var sb = new StringBuilder();

        var words = input.Trim().Split(' ');

        foreach (var word in words)
        {
            var modifiedWord = new StringBuilder(word);

            if (modifiedWord[0].ToString().ToLower() == "p")
            {
                modifiedWord[0] = 'S';
            }

            var lastIndex = modifiedWord.Length - 1;

            if (modifiedWord[lastIndex].ToString().ToLower() == "n")
            {
                modifiedWord[lastIndex] = 'O';
            }

            sb.Append(modifiedWord.ToString());
            sb.Append(' ');
        }

        return sb.ToString().Trim();
    }
}
