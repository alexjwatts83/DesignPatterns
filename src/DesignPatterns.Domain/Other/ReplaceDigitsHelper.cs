namespace DesignPatterns.Domain.Other;
public static class ReplaceDigitsHelper
{
    // TODO: fix this method - fix bugs, make more efficient, and return correct result
    public static string ReplaceDigits(string sentence)
    {
        string[] words = ["zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"];
        for (var i = 0; i < words.Length; i++)
        {
            sentence = sentence.Replace(i.ToString(), words[i]);
        }
        return sentence;
    }
}
