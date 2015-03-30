// Write a program that reads a string from the console and finds all
// products that contain this string. Ensure you handle 
// correctly characters like ', %, ", \ and _.

namespace _08.Find_All_Products_In_String
{
    using System.Data.SqlClient;
    using System;
    using System.Collections.Generic;

    class FindAllProductsInString
    {
        public static IList<string> AllProductsListFromDatabase(IList<string> productsList)
        {
            string server = "Server=.;";
            string database = "Database=Northwind;";
            string security = "Integrated Security=true";
            var dbConnection = new SqlConnection(server + " " + database + " " + security);

            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand dbCommand = new SqlCommand("SELECT ProductName FROM Products", dbConnection);

                SqlDataReader reader = dbCommand.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        productsList.Add((string)reader["ProductName"]);
                    }
                }
                reader.Close();
            }
            dbConnection.Close();

            return productsList;
        }

        private static void FindProducts(IList<string> productList, string[] productsInput)
        {
            foreach (var productInList in productList)
            {
                foreach (var imputs in productsInput)
                {
                    var trimmedinput = imputs.Trim();
                    if (trimmedinput == productInList)
                    {
                        Console.WriteLine("This imput {0} is in Product list", trimmedinput);
                    }
                }
            }
        }

        private static void Main()
        {
            IList<string> productList = new List<string>();

            productList = AllProductsListFromDatabase(productList);

            // var input = "_ Chai/ Geitost' Chang%Gula Malacca\"Dsv";
            var input = Console.ReadLine();

            string[] productsInput = input.Split(new char[] {'_', '\'', '%', '\"', '\\', '/'});

            FindProducts(productList, productsInput);
        }
    }
}
