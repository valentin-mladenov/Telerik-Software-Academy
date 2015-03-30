// Write a program that retrieves from the Northwind database all product
// categories and the names of the products in each category. 
// Can you do this with a single SQL query (with table join)?

namespace _03.Product_Categories_And_Product_Names
{
    using System;
    using System.Data.SqlClient;

    public class ProductCategoriesAndProductNames
    {
        private static void Main()
        {
            string server = "Server=.;";
            string database = "Database=Northwind;";
            string security = "Integrated Security=true";
            var dbConnection = new SqlConnection(server + " " + database + " " + security);

            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand dbCommand = new SqlCommand("SELECT c.CategoryName, p.ProductName " +
                                                      "FROM [Categories] c JOIN Products p " +
                                                      " ON c.CategoryID = p.CategoryID", dbConnection);

                SqlDataReader reader = dbCommand.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];

                        Console.WriteLine("The Product {0} is in Category {1}", productName, categoryName);
                    }
                }
                reader.Close();
            }
            dbConnection.Close();
        }
    }
}