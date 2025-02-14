using System.Text;

namespace DesignPatterns.Domain.Other;
public static class ReplaceDigitsHelper
{
    // TODO: fix this method - fix bugs, make more efficient, and return correct result
    public static string ReplaceDigits(string sentence)
    {
        string[] words = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
        var sentenceBuilder = new StringBuilder();

        for (var i = 0; i < sentence.Length; i++)
        {
            var letter = sentence[i].ToString();
            if (int.TryParse(letter, out int num))
            {
                var word = words[num];
                sentenceBuilder.Append(word);
            }
            else
            {
                sentenceBuilder.Append(letter);
            }
        }

        return sentenceBuilder.ToString();
    }
}
