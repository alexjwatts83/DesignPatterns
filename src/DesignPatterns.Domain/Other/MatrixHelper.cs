using System.Collections;

namespace DesignPatterns.Domain.Other;

// TODO: optimize this class
public class Matrix<T> : IEnumerable<T>
{
    private readonly T[] _data;

    public Matrix(int rows, int cols)
    {
        Rows = rows;
        Columns = cols;
        _data = new T[Rows * Columns];
    }

    public int Rows { get; private set; }
    public int Columns { get; private set; }

    public T this[int row, int col]
    {
        get { return _data[GetIndex(row, col)]; }
        set { _data[GetIndex(row, col)] = value; }
    }

    private int GetIndex(int row, int col) => col * Rows + row;

    public IEnumerator<T> GetEnumerator()
    {
        return GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        for (int j = 0; j < Columns; j++)
            for (int i = 0; i < Rows; i++)
                yield return _data[GetIndex(i, j)];
    }
}

public class MatrixHelper
{
    public static Matrix<int> Multiply(Matrix<int> a, Matrix<int> b)
    {
        var result = new Matrix<int>(a.Rows, b.Columns);
        for (int i = 0; i < result.Rows; i++)
        {
            for (int j = 0; j < result.Columns; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < a.Columns; k++)
                {
                    result[i, j] += (a[i, k] * b[k, j]);
                }

            }
        }
        return result;
    }
}
