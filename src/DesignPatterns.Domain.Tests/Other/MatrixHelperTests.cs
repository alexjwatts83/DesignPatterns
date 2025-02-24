using DesignPatterns.Domain.Other;

namespace DesignPatterns.Domain.Tests.Other;

public class MatrixHelperTests
{
    [Fact()]
    public void MultiplyTest()
    {
        // arrange
        var a = new Matrix<int>(2, 3);
        var b = new Matrix<int>(3, 2);

        a[0, 0] = 1;
        a[0, 1] = 2;
        a[0, 2] = 3;
        a[1, 0] = 4;
        a[1, 1] = 5;
        a[1, 2] = 6;


        b[0, 0] = 7;
        b[0, 1] = 8;

        b[1, 0] = 9;
        b[1, 1] = 10;

        b[2, 0] = 11;
        b[2, 1] = 12;

        // act
        var result = MatrixHelper.Multiply(a, b);

        // assert
        var expected = new Matrix<int>(2, 2);
        expected[0, 0] = 58;
        expected[0, 1] = 64;

        expected[1, 0] = 139;
        expected[1, 1] = 154;

        result.ShouldBe(expected);
    }
}