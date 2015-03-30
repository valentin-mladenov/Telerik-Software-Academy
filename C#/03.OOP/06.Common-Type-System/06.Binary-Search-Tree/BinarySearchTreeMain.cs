using System;
using System.Linq;

//* 
//Define the data structure binary search tree with
//operations for "adding new element", "searching element"
//and "deleting elements". It is not necessary to keep the
//tree balanced. Implement the standard methods from System.Object
//– ToString(), Equals(…), GetHashCode() and the operators
//for comparison  == and !=. Add and implement the ICloneable
//interface for deep copy of the tree. Remark: Use two types –
//structure BinarySearchTree (for the tree) and class TreeNode
//(for the tree elements). Implement IEnumerable<T> to traverse the tree.

namespace _06.Binary_Search_Tree
{
    class BinarySearchTreeMain
    {
        static void Main(string[] args)
        {
            // I was so close to do it alone.... Sigh next time.
            Console.Title = "I was so close to do it alone....";
            Console.WriteLine("I was so close to do it alone.... Sigh next time.");

            BSTree<int, int> arra = new BSTree<int, int>();

            arra.Insert(56, 23);
            arra.Insert(85, 63);

            foreach (var item in arra)
            {
                Console.WriteLine(item.ToString());
            }

            BSTree<int, int> tree1 = new BSTree<int, int>();

            tree1.Insert(1, 15);
            tree1.Insert(56544, 46545);
            tree1.Insert(43, 43);
            tree1.Insert(-43, -43);
            tree1.Insert(-66, -66);

            Console.WriteLine(tree1);

            Console.WriteLine("hash codes: " + tree1.GetHashCode() + " " + arra.GetHashCode());
            Console.WriteLine("tree1 == tree2 " + (tree1 == arra));

            foreach (var item in tree1)
            {
                Console.WriteLine(item);
            }

            int sfdga = 0 / 2;

            Console.WriteLine(sfdga);
        }
    }
}
