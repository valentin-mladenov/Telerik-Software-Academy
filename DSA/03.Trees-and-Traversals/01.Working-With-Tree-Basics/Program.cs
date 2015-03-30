// You are given a tree of N nodes represented as a set of N-1 pairs of nodes (parent node, child node), each in the range (0..N-1). 
// Write a program to read the tree and find:
//      a)the root node
//      b)all leaf nodes
//      c)all middle nodes
//      d)the longest path in the tree
//   *  e)all paths in the tree with given sum S of their nodes
//   *  f)all subtrees with given sum S of their nodes

namespace _01.Working_With_Tree_Basics
{
    using System;
    using System.Collections.Generic;

    internal class Program
    {
        private static void Main(string[] args)
        {
            int nodeCount = int.Parse(Console.ReadLine());
            IList<TreeNode<int>> nodes = new List<TreeNode<int>>(nodeCount);

            for (int i = 0; i < nodeCount; i++)
            {
                nodes.Add(new TreeNode<int>(i));
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Length == 0)
                {
                    break;
                }

                string[] inputStrings = input.Split(' ');

                int parent = int.Parse(inputStrings[0]);
                int child = int.Parse(inputStrings[1]);

                nodes[parent].AddChild(nodes[child]);
            }

            Tree<int> tree = new Tree<int>(0);
            foreach (var treeNode in nodes)
            {
                if (!treeNode.HasParent)
                {
                    tree.Root = treeNode;

                    break;
                }
            }

            tree.TraverseDFS();

            // a) Find the root node and set in Tree
            Console.WriteLine("The root node is: " + tree.Root.Data);

            // b) Find all leaf nodes
            Stack<int> leaves = tree.FindAllLeaves();
            Console.WriteLine("All leaf nodes: " + string.Join(", ", leaves));

            // c) Find all middle nodes
            Stack<int> branches = tree.FindAllMiddleNodes();
            Console.WriteLine("All middle nodes: " + string.Join(", ", branches));

            // d) Find the longest path in the tree
            Console.WriteLine("Longest path is: " + tree.FindLongestPath());

            // * e) Find all paths in the tree with given sum S of their nodes
            int sumS = 14;
            List<List<TreeNode<int>>> paths = tree.FindPathsWithSum(sumS);
            Console.WriteLine("Paths with sum of {0}:", sumS);
            foreach (var list in paths)
            {
                foreach (var item in list)
                {
                    Console.Write(item.Data + " ");
                }
                Console.WriteLine();
            }

            // * f) Find all subtrees with given sum S of their nodes
            // Din't get that far...
        }
    }
}