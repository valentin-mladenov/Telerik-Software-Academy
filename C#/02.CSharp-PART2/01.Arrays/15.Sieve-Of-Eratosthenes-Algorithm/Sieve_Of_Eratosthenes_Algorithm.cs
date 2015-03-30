using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Sieve_Of_Eratosthenes_Algorithm
{
    static void Main(string[] args)
    {
        int tenMilion = 100000;
        //int squrt10Mill = (int)Math.Sqrt(tenMilion);

        //int[] arrayPrime = new int[tenMilion];
        //bool prime = false;

        List<int> primes = new List<int>();

        for (int i = 0; i < tenMilion; i++)
        {
            if ((i == 1) || (i == 2) || (i == 3) || (i == 5) || (i == 7) || i==11)
	        {
                primes.Add(i);
	        }
            else if ((i % 2  == 0) || (i % 3  == 0) || (i % 5  == 0) || (i % 7  == 0) || (i % 11  == 0))
            {
            }
            else
            {
                int squrtI = (int)Math.Sqrt(i);
                bool prime = true;

                for (int j = 1; j <= squrtI; j++)
                {
                    
                    if (i % primes[j] == 0)
	                {
                        prime = false;
	                }
                }
                if (prime == true)
                {
                    primes.Add(i);
                }
            }
            
        }

        foreach (var number in primes)
        {
            Console.Write(number + ", ");
        }
    }
}