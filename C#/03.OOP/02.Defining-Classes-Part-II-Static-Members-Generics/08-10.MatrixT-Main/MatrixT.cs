using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Matrix<T>
    where T : struct, IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
{
    private int row;
    private int col;
    private T[,] matrix;

    public Matrix(int row,int col)
    {
        if (row < 0)
        {
            throw new IndexOutOfRangeException("Rows must be 0 or positive numbers.");
        }
        else if (col < 0)
        {
            throw new IndexOutOfRangeException("Columns must be 0 or positive numbers.");
        }
        else
        {
            this.row = row;
            this.col = col;
            this.matrix = new T[row, col];
        }
    }

    public T[,] TheMatrix
    {
        set { this.matrix = value; }
        get { return this.matrix; }
    }

    public T this[int row, int col]
    {
        set
        {
            if (row < 0 || row > this.row)
            {
                throw new IndexOutOfRangeException("Row is outside the matrix.");
            }
            else if (col < 0 || col > this.col)
            {
                throw new IndexOutOfRangeException("Column is Outside the matrix.");
            }
            else
            {
                this.matrix[row, col] = value;
            }
        }
        get { return this.matrix[row, col]; }
    }

    public int Row(int row)
    {
        if (row < 0)
        {
            throw new IndexOutOfRangeException("Rows must be 0 or positive numbers.");
        }
        else
        {
            return this.row = row;
        }
    }

    public int Column(int col)
    {
        if (col < 0)
        {
            throw new IndexOutOfRangeException("Columns must be 0 or positive numbers.");
        }
        else
        {
            return this.col = col;
        }
    }

    public T RowColValue(int row, int col)
    {
        return this.matrix[row, col];
    }

    public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
    {
        if ((first.row != second.row) && (first.col != second.col))
        {
            throw new ArgumentException("The Matices are different in size!");
        }
        else
        {
            Matrix<T> output = new Matrix<T>(first.row, first.col);
            for (int row = 0; row < first.row; row++)
            {
                for (int col = 0; col < first.col; col++)
                {
                    output[row, col] = first[row, col] + (dynamic)second[row, col];
                }
            }
            return output;
        }
    }

    public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
    {
        if ((first.row != second.row) && (first.col != second.col))
        {
            throw new ArgumentException("The Matices are different in size!");
        }
        else
        {
            Matrix<T> output = new Matrix<T>(first.row, first.col);
            for (int row = 0; row < first.row; row++)
            {
                for (int col = 0; col < first.col; col++)
                {
                    output[row, col] = first[row, col] - (dynamic)second[row, col];
                }
            }
            return output;
        }
    }

    public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
    {
        if ((first.row != second.row) && (first.col != second.col))
        {
            throw new ArgumentException("The Matices are different in size!");
        }
        else
        {
            Matrix<T> output = new Matrix<T>(first.row, first.col);
            for (int row = 0; row < first.row; row++)
            {
                for (int col = 0; col < first.col; col++)
                {
                    output[row, col] = first[row, col] * (dynamic)second[row, col];
                }
            }
            return output;
        }
    }

    public static bool operator true(Matrix<T> matrix)
    {
        for (int row = 0; row < matrix.row; row++)
        {
            for (int col = 0; col < matrix.col; col++)
            {
                if (matrix[row,col].Equals(default(T)))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool operator false(Matrix<T> matrix)
    {
        for (int row = 0; row < matrix.row; row++)
        {
            for (int col = 0; col < matrix.col; col++)
            {
                if (matrix[row, col].Equals(default(T)))
                {
                    return false;
                }
            }
        }
        return true;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < this.row; i++)
        {
            for (int j = 0; j < this.col; j++)
            {
                if (j == 0)
                {
                    sb.Append("|".PadRight(1));
                }
                sb.Append(Convert.ToString(this.matrix[i, j]).PadRight(1));
                sb.Append("|".PadRight(1));
            }
            sb.Append("\n");
            for (int j = 0; j < this.row; j++)
            {
                sb.Append("--");
            }
            sb.Append("\n");
        }
        return sb.ToString();
    }
}