using System;

            //We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence of operators that modifies n to hold the value v at the position p from the binary representation of n.
            //        Example: n = 5 (00000101), p=3, v=1  13 (00001101)
            //    n = 5 (00000101), p=2, v=0  1 (00000001)


class Sequence_Of_Operators
{
    static void Main()
    {
        Console.WriteLine("Enter a number N:");
        int numberN = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a bit position P:");
        int positionP = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter a modifier V (0 or 1):");
        int modifierV = int.Parse(Console.ReadLine());
        {
            if (modifierV == 1)
            {
                int mask = modifierV << positionP;
                int modifiedNumber1 = mask | numberN;
                Console.WriteLine("The modified number N has value of: {0}", modifiedNumber1);
            }
            else
            {
                int mask = ~(1 << positionP);
                int modifiedNumber0 = mask & numberN;
                Console.WriteLine("The modified number N has value of: {0}", modifiedNumber0);
            }
        }            
    }
}
