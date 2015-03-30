// Write a program that retrieves from the Northwind sample
// database in MS SQL Server the number of  rows in the Categories table.

namespace _01.Retrieve_Categories_From_Northwind
{
    using System.Data.SqlClient;
    using System;

    public class RetrieveCategoriesFromNorthwind
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
                SqlCommand dbCommand = new SqlCommand("SELECT COUNT(*) AS Rows FROM Categories", dbConnection);

                int result = (int) dbCommand.ExecuteScalar();

                Console.WriteLine("The rows in Categories are {0}", result);
            }
            dbConnection.Close();
        }
    }
}