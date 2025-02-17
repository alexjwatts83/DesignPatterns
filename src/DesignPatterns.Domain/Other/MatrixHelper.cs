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
        get { return _data[col * Rows + row]; }
        set { _data[col * Rows + row] = value; }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        for (int j = 0; j < Columns; j++) 
        {
            for (int i = 0; i < Rows; i++)
                yield return _data[j * Rows + i];
        }
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
                    var aValue = a[i, k];
                    var bValue = b[k, j];

                    result[i, j] += (a[i, k] * b[k, j]);
                }
                    
            }
        }
        return result;
    }
}
