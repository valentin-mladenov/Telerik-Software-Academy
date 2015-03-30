namespace _2.Millions_Of_Articles
{
    using System;
    using System.Collections.Generic;

    using Wintellect.PowerCollections;

    public class Program
    {
        public static void Main()
        {
            var articles = new List<Article>();

            articles.Add(new Article("Yogurth", "Vereia", 3575889579, 1.23M));
            articles.Add(new Article("Milk", "Vereia", 56756767, 1.98M));
            articles.Add(new Article("Apple", "Local vendor", 4848673626, 5.93M));
            articles.Add(new Article("Tomato", "Local vendor", 12587676756767, 1.98M));
            articles.Add(new Article("Meatball", "EcoPig", 432566788656, 10.93M));

            var multiOrderedArticles = new OrderedMultiDictionary<decimal, Article>(true);

            foreach (var article in articles)
            {
                multiOrderedArticles.Add(article.Price, article);
            }

            var startPrice = 1.25M;
            var endPrice = 6M;

            var articlesInPriceRange = multiOrderedArticles.Range(startPrice, true, endPrice, true);

            foreach (var article in articlesInPriceRange)
            {
                Console.WriteLine(article.ToString());
            }
        }
    }
}
