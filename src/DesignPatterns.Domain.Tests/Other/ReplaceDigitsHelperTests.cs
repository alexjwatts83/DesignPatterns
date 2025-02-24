using DesignPatterns.Domain.Other;

namespace DesignPatterns.Domain.Tests.Other;

public class ReplaceDigitsHelperTests
{
    [Theory]
    [InlineData("4 score and 7 years ago, 8 men had the same PIN code: 6571", "four score and seven years ago, eight men had the same PIN code: six five seven one")]
    public void ReplaceDigitsTest(string input, string expected)
    {
        // arrange
        var helper = new ReplaceDigitsHelper();

        // act
        var result = helper.ReplaceDigits(input);

        // assert
        result.ShouldBe(expected);
    }
}