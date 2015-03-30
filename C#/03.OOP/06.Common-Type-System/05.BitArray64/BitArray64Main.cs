using System;
using System.Linq;

//Define a class BitArray64 to hold 64 bit values
//inside an ulong value. Implement IEnumerable<int>
//and Equals(…), GetHashCode(), [], == and !=.

namespace _05.BitArray64
{
    class BitArray64Main
    {
        static void Main()
        {
            BitArray64 arr64 = new BitArray64(5);
            foreach (var item in arr64)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            arr64[37] = true;
            Console.WriteLine(arr64.Number);

            Console.WriteLine(arr64.ToString());

            arr64[3] = true;
            Console.WriteLine(arr64.Number);
            foreach (var item in arr64)
            {
                Console.Write(item);
            }
            Console.WriteLine();

            BitArray64 arr614 = new BitArray64(5478545);

            Console.WriteLine(arr614.ToString());

            Console.WriteLine(BitArray64.Equals(arr64,arr614));
            Console.WriteLine(arr614!=arr64);
        }
    }
}
