// Write a program to read a large collection of products (name + price) and efficiently
// find the first 20 products in the price range [a…b].
// Test for 500 000 products and 10 000 price searches.
// Hint: you may use OrderedBag<T> and sub-ranges.

// Try to make it with BigList... was too slow. Waste of time
namespace _2.Fast_Find_In_Collection
{
    using System;
    using System.Text;

    using Wintellect.PowerCollections;

    internal class FastFindInCollection
    {
        public static void OperationsWithBigList(BigList<Product> productsBigList)
        {
            Console.WriteLine("BigList");
            Console.WriteLine("Start Add: " + DateTime.Now);

            var name = "A";
            for (int i = 0; i < 500000; i++)
            {
                var sb = new StringBuilder();
                sb.Append(name + (500000 - i));
                var product = new Product(sb.ToString(), i * 2);
                productsBigList.Add(product);
            }

            Console.WriteLine("End Add and start Sort: " + DateTime.Now);

            productsBigList.Sort();

            Console.WriteLine("End Sort and start Find: " + DateTime.Now);

            for (int i = 100000; i < 101000; i++)
            {
                var priceStart = i * 2;
                int priceEnd = (i * 2) + 30;

                var startPriceIndex = 0;

                for (int j = 0; j < productsBigList.Count; j++)
                {
                    if (productsBigList[j].Price == priceStart)
                    {
                        startPriceIndex = j;
                        break;
                    }
                }

                var currentPriceRange = productsBigList.Range(startPriceIndex, 20);

                var resultPriceRange = new BigList<Product>();
                foreach (var product in currentPriceRange)
                {
                    if (product.Price <= priceEnd)
                    {
                        resultPriceRange.Add(product);
                    }
                }

                // Console.WriteLine(resultPriceRange);
            }

            Console.WriteLine("End Find: " + DateTime.Now);
        }

        public static void OperationsWithOrderedBag(OrderedBag<Product> productsOrderedSet)
        {
            Console.WriteLine("OrderedBag");
            Console.WriteLine("Start Add with Sort: " + DateTime.Now);

            var name = "B";
            for (int i = 0; i < 500000; i++)
            {
                var sb = new StringBuilder();
                sb.Append(name + (500000 - i));
                var product = new Product(sb.ToString(), i);
                productsOrderedSet.Add(product);
            }

            Console.WriteLine("End Add with Sort and start Find: " + DateTime.Now);

            for (int i = 100000; i < 110000; i++)
            {
                var priceStart = i;
                int priceEnd = i + 30;

                var startPriceProduct = new Product("StartItem", priceStart - 1);
                var endpriceproduct = new Product("EndItem", priceEnd);

                var currentPriceRange = productsOrderedSet.Range(startPriceProduct, false, endpriceproduct, false);

                var resultPriceRange = new OrderedBag<Product>();
                foreach (var product in currentPriceRange)
                {
                    if (product.Price <= priceEnd)
                    {
                        resultPriceRange.Add(product);
                    }
                    if (resultPriceRange.Count == 20)
                    {
                        break;
                    }
                }

                // Console.WriteLine(resultPriceRange);
            }

            Console.WriteLine("End Find: " + DateTime.Now);
        }

        private static void Main()
        {
            var productsBigList = new BigList<Product>();
            var productsOrderedSet = new OrderedBag<Product>();

            //OperationsWithBigList(productsBigList);

            Console.WriteLine();

            OperationsWithOrderedBag(productsOrderedSet);
        }
    }
}