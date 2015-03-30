using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//*
//Write a class Matrix, to holds a
//matrix of integers. Overload the
//operators for adding, subtracting 
//and multiplying of matrices, indexer
//for accessing the matrix content and
//ToString().


class Matrix
{
    private int[,] matrix;
    private int rows;
    private int columns;

    public int[,] Value
    {
        get
        {
            return this.matrix;
        }
        set
        {
            this.matrix = value;
            this.rows = value.GetLength(0);
            this.columns = value.GetLength(1);
        }
    }

    public int Rows
    {
        get
        {
            return this.rows;
        }
    }

    public int Columns
    {
        get
        {
            return this.columns;
        }
    }

    public Matrix(int[,] matrix)
    {
        this.Value = (int[,])matrix.Clone();
    }

    public Matrix(int rows, int cols) : this(new int[rows, cols]) { }

    public static Matrix operator +(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
        {
            throw new FormatException("Matrixes must have same dimensions!");
        }
        else
        {
            Matrix result = new Matrix(a.Rows,a.Columns);
            for (int i = 0; i < a.Rows; i++)
			{
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
			}
            return result;
        }
    }

    public static Matrix operator -(Matrix a, Matrix b)
    {
        if (a.Rows != b.Rows || a.Columns != b.Columns)
        {
            throw new FormatException("Matrixes must have same dimensions!");
        }
        else
        {
            Matrix result = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }
            return result;
        }
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        if (b.Rows != a.Columns)
        {
            throw new FormatException("irst matrix columns number must be equal to second matrix rows number!");
        }
        else
        {
            Matrix result = new Matrix(a.Rows, a.Columns);
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < b.Columns; j++)
                {
                    for (int k = 0; k < a.Columns; k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }
    }

    public int this[int i, int j]
    {
        get
        {
            return this.Value[i, j];
        }
        set
        {
            this.Value[i, j] = value;
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(this[0, 0]);
        for (int j = 1; j < this.Columns; j++)
        {
            result.AppendFormat(" {0}", this[0, j]);
        }
        for (int i = 1; i < this.Rows; i++)
        {
            result.AppendFormat(" {0}", this[i, 0]);
            for (int j = 1; j < this.Columns; j++)
            {
                result.AppendFormat("\n {0}", this[i, j]);
            }
        }
        return base.ToString();
    }

    static void Main()
    {
        Matrix a = new Matrix(3, 4);
        a.Value[1, 1] = 5;
        Matrix b = new Matrix(3, 4);
        b.Value[1, 1] = 3;
        Matrix c = new Matrix(4, 2);
        c.Value[1, 1] = 3;

        Console.WriteLine("a.Rows: {0}; a.Columns: {1}",a.Rows, a.Columns);
        Console.WriteLine(a);
        Console.WriteLine();

        Console.WriteLine("b.Rows: {0}; b.Columns: {1}", b.Rows, b.Columns);
        Console.WriteLine(b);
        Console.WriteLine();

        Console.WriteLine("c.Rows: {0}; c.Columns: {1}", c.Rows, c.Columns);
        Console.WriteLine(c);
        Console.WriteLine();

        Console.WriteLine("\na + b =\n{0}", a + b);
        Console.WriteLine("\na - b =\n{0}", a - b);
        Console.WriteLine("\na * c =\n{0}", a * c);

        Console.WriteLine("\na + c =");
        try 
	    {
            Console.WriteLine("\na + c =\n{0}", a + c);
	    }
	    catch (Exception e)
	    {
            Console.WriteLine(e.Message);
	    }

        Console.WriteLine("\nb - c =");
        try
        {
            Console.WriteLine("\nb - c =\n{0}", b - c);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine("\na * b =");
        try
        {
            Console.WriteLine("\n a * b =\n{0}", a * b);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        int[,] v0 = { { 4, 8, 15, 16, 23, 42 } };
        Matrix v = new Matrix(v0);
        int[,] t0 = { { 1 }, { 1 }, { 1 }, { 1 }, { 1 }, { 1 } };
        Matrix t = new Matrix(t0);

        Console.WriteLine();
        Console.WriteLine("v.Rows: {0}; v.Columns: {1}", v.Rows, v.Columns);
        Console.WriteLine(v);
        Console.WriteLine();

        Console.WriteLine("t.Rows: {0}; t.Columns: {1}", t.Rows, t.Columns);
        Console.WriteLine(t);
        Console.WriteLine();

        Console.WriteLine("\nv * t =\n{0}", v * t);

        Console.WriteLine();
        int i = 0;
        int j = 0;
        Console.WriteLine("(v * t)[{1},{2}] = {0}", (v * t)[i, j], i, j);
    }
}