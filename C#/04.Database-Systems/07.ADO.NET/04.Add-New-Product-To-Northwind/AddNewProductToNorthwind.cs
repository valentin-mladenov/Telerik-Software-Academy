// Write a method that adds a new product in the products
// table in the Northwind database. Use a parameterized SQL command.

namespace _04.Add_New_Product_To_Northwind
{
    using System.Data.SqlClient;

    public class AddNewProductToNorthwind
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
                string productName = "Piper";
                int supplierID = 3;
                int categoryID = 4;

                SqlCommand dbCommand = new SqlCommand("INSERT INTO Products " +
                                                      "([ProductName], [SupplierID], [CategoryID]) VALUES" +
                                                      "(@productName, @supplierID, @categoryID)", dbConnection);

                dbCommand.Parameters.AddWithValue("@productName", productName);
                dbCommand.Parameters.AddWithValue("@supplierID", supplierID);
                dbCommand.Parameters.AddWithValue("@categoryID", categoryID);

                dbCommand.ExecuteNonQuery();
            }
            dbConnection.Close();
        }
    }
}
