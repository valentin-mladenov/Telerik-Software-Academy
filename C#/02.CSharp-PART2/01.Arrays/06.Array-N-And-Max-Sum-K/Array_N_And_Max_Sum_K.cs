using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads two integer numbers N 
//and K and an array of N elements from the console. 
//Find in the array those K elements that have maximal sum.


class Array_N_And_Max_Sum_K
{
    static void Main()
    {
        Console.WriteLine("Enter Number N and Number K.");

        int numberN = int.Parse(Console.ReadLine());
        int numberK = int.Parse(Console.ReadLine());

        if (numberK > numberN)
        {
            Console.WriteLine("Error: Number K must be smaller than Number N. Enter new numbers:");
            Main();
        }

        else
        {

            List<int> listN = new List<int>();
            List<int> listK = new List<int>();


            for (int i = 0; i < numberN; i++)
            {
                Console.Write("List N [{0}] = ", i);
                listN.Add(int.Parse(Console.ReadLine()));
            }

            int numberNtoK = 0;
            int maxNumber = 0;

            for (int j = 0; j < numberK; j++)
            {
                int numberNMinusK = numberN - j;

                for (int i = 0; i < numberNMinusK; i++)
                {
                    if (maxNumber < listN[i])
                    {
                        numberNtoK = listN[i];
                    }
                    maxNumber = Math.Max(listN[i], maxNumber);
                }

                listN.Remove(numberNtoK);
                maxNumber = 0;
                listK.Add(numberNtoK);
            }

            int sumK = listK.Sum();

            foreach (var number in listK)
            {
                Console.Write(number + ", ");
            }
            Console.WriteLine(" are the K elemnets in N array with max sum of {0}",sumK);
        }
    }
}