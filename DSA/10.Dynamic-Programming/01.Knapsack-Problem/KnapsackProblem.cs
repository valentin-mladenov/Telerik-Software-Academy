// Write a program based on dynamic programming to solve the "Knapsack Problem": you are given N products,
// each has weight Wi and costs Ci and a knapsack of capacity M and you want to put inside a subset of the
// products with highest cost and weight ≤ M. The numbers N, M, Wi and Ci are integers
// in the range [1..500]. Example: M=10 kg, N=6, products:
// beer – weight=3, cost=2
// vodka – weight=8, cost=12
// cheese – weight=4, cost=5
// nuts – weight=1, cost=4
// ham – weight=2, cost=3
// whiskey – weight=8, cost=13

namespace _01.Knapsack_Problem
{
    using System;
    using System.Collections.Generic;

    internal class KnapsackProblem
    {
        private static void Main()
        {
            var itemArray = new List<Item>
                                {
                                    new Item(3, 2, "Beer"),
                                    new Item(8, 12, "Vodka"),
                                    new Item(4, 5, "Cheese"),
                                    new Item(1, 4, "Nuts"),
                                    new Item(2, 3, "Ham"),
                                    new Item(8, 13, "Wiskey")
                                };

            int capacity = 10;

            var result = KnapsackDynamic(itemArray, capacity);

            foreach (var item in result)
            {
                Console.WriteLine("Name: "+ item.Name+" Price: "+item.Price+" Weight: "+item.Weight);
            }
        }

        public static List<Item> KnapsackDynamic(List<Item> items, int capacity)
        {
            var valuesMatrix = new int[items.Count, capacity + 1];
            var keepValueMatrix = new int[items.Count, capacity + 1];

            for (int x = 0; x < items.Count; x++)
            {
                valuesMatrix[x, 0] = 0;
                keepValueMatrix[x, 0] = 0;
            }

            for (int y = 1; y <= capacity; y++)
            {
                if (items[0].Weight <= y)
                {
                    valuesMatrix[0, y] = items[0].Price;
                    keepValueMatrix[0, y] = 1;
                }
                else
                {
                    valuesMatrix[0, y] = 0;
                    keepValueMatrix[0, y] = 0;
                }
            }

            for (int x = 0; x <= items.Count - 2; x++)
            {
                for (int y = 1; y <= capacity; y++)
                {
                    var currentItem = items[x + 1];
                    if (currentItem.Weight > y)
                    {
                        // if not enough space - skip current item
                        valuesMatrix[x + 1, y] = valuesMatrix[x, y];
                        continue;
                    }
                    int valueWhenDropping = valuesMatrix[x, y];
                    int valueWhenTaking = valuesMatrix[x, y - currentItem.Weight] + currentItem.Price;

                    //// which is better?
                    if (valueWhenTaking > valueWhenDropping)
                    {
                        valuesMatrix[x + 1, y] = valueWhenTaking;
                        keepValueMatrix[x + 1, y] = 1;
                    }
                    else
                    {
                        valuesMatrix[x + 1, y] = valueWhenDropping;
                        keepValueMatrix[x + 1, y] = 0;
                    }
                }
            }

            var result = new List<Item>();
            {
                int remainingSpace = capacity;
                int item = items.Count - 1;
                while (item >= 0 && remainingSpace >= 0)
                {
                    // if we've taken the item
                    if (keepValueMatrix[item, remainingSpace] == 1)
                    {
                        // go up and left
                        result.Add(items[item]);
                        remainingSpace -= items[item].Weight;
                        item -= 1;
                    }
                    else
                    {
                        // else go up
                        item -= 1;
                    }
                }
            }

            return result;
        }
    }
}