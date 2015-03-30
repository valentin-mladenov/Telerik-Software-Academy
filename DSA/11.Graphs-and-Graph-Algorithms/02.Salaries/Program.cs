namespace _02.Salaries
{
    using System;

    class Program
    {
        public static char[,] matrix;

        public static long[,] salaryMtrix;

        static void Main()
        {
            var employees = int.Parse(Console.ReadLine());

            matrix = new char[employees, employees];
            salaryMtrix = new long[employees, employees];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] currentInput = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentInput[col];
                }
            }

            long total = 0;
            for (int i = 0; i < employees; i++)
            {
                total += GetSalary(i);
            }
            Console.WriteLine(total);
        }

        public static long GetSalary(int employee)
        {
            long result = 0;
            var hasNoWorkers = true;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                if (matrix[employee, i] == 'Y')
                {
                    if (salaryMtrix[employee, i] == 0)
                    {
                        result += GetSalary(i);
                        salaryMtrix[employee, i] = GetSalary(i);
                    }
                    else
                    {
                        result += salaryMtrix[employee, i];
                    }
                    
                    hasNoWorkers = false;
                }
            }

            if (hasNoWorkers)
            {
                return result + 1;
            }

            return result;
        }
    }
}