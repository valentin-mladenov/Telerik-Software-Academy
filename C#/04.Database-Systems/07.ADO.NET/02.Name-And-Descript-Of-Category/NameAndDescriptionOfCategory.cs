// Write a program that retrieves the name and description
// of all categories in the Northwind DB.

namespace _02.Name_And_Descript_Of_Category
{
    using System.Data.SqlClient;
    using System;

    public class NameAndDescriptionOfCategory
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
                SqlCommand dbCommand = new SqlCommand("SELECT * FROM Categories", dbConnection);

                SqlDataReader reader = dbCommand.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string) reader["CategoryName"];
                        string desription = (string) reader["Description"];

                        Console.WriteLine("The Name is: {1} and Description is: {0}", desription, name);
                    }
                }
                reader.Close();
            }
            dbConnection.Close();
        }
    }
}