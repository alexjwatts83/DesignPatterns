using System.Text;

namespace DesignPatterns.Domain.Other;

public class ReplaceDigitsHelper
{
    // TODO: fix this method - fix bugs, make more efficient, and return correct result
    public string ReplaceDigits(string sentence)
    {
        string[] words = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
        var sentenceBuilder = new StringBuilder();
        var lastLetterWasNumberic = false;
        var len = sentence.Length;
        for (var i = 0; i < len; i++)
        {
            var letter = sentence[i].ToString();
            if (!string.IsNullOrEmpty(letter) && int.TryParse(letter, out int num))
            {
                if (lastLetterWasNumberic)
                    sentenceBuilder.Append(" ");

                var word = words[num];
                
                sentenceBuilder.Append(word);

                lastLetterWasNumberic = true;
            }
            else
            {
                sentenceBuilder.Append(letter);
                lastLetterWasNumberic = false;
            }
        }

        return sentenceBuilder.ToString();
    }
}
