// Download and install MySQL database, MySQL Connector/Net (.NET Data Provider for MySQL)
// + MySQL Workbench GUI administration tool . Create a MySQL database to store Books
// (title, author, publish date and ISBN). Write methods for listing all books,
// finding a book by name and adding a book.

namespace _09.MySQL_Opertions
{
    using System;
    using MySql.Data.MySqlClient;
    using System.Text;

    internal class MySQLOperations
    {
        public static void MySQLReader(string connectionStr)
        {
            MySqlConnection connection = new MySqlConnection(connectionStr);
            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand("select * from books", connection);
                MySqlDataReader reader = command.ExecuteReader();
                StringBuilder str = new StringBuilder();
                while (reader.Read())
                {
                    str.AppendLine("ID: " + reader[0] + " Title: " + reader[1] +
                                   " Author: " + reader[2] + " Publish at: " +
                                   reader[3] + " ISBN " + reader[4]);
                }
                reader.Close();
                Console.WriteLine(str.ToString());
            }
            connection.Close();
        }

        public static void MySQLWriter(string connectionStr)
        {
            MySqlConnection connection = new MySqlConnection(connectionStr);
            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO books (Title, Author,PublishDate,ISBN) " +
                                                        "VALUES (?title, ?author, ?publishDate, ?ISBN)", connection);

                command.Parameters.AddWithValue("?title", "C# Tutorial");
                command.Parameters.AddWithValue("?author", "Nakov");
                command.Parameters.AddWithValue("?publishDate", "2007-05-16");
                command.Parameters.AddWithValue("?ISBN", 4630973);
                command.ExecuteNonQuery();
            }
            connection.Close();
        }

        public static void MySQLFinder(string connectionStr, string title)
        {
            MySqlConnection connection = new MySqlConnection(connectionStr);
            connection.Open();
            using (connection)
            {
                MySqlCommand command = new MySqlCommand("select Title from books", connection);
                MySqlDataReader reader = command.ExecuteReader();
                StringBuilder str = new StringBuilder();
                while (reader.Read())
                {
                    string titleDB = (string) reader[0];
                    if (title == titleDB)
                    {
                        str.AppendLine(" Title: " + reader[0] + " found");
                        break;
                    }
                }
                reader.Close();
                Console.WriteLine(str.Length == 0 ? "Title not found." : str.ToString());
            }
            connection.Close();
        }

        private static void Main()
        {
            // A lot of repeating code, but not enough time to meke it in KPK fashion. 

            Console.Write("Enter pass: ");
            string pass = Console.ReadLine();
            // string pass = "";

            Console.Write("Enter Book Title: ");
            string title = Console.ReadLine();
            // string title = "Learn MySQL";

            string connectionStr = "Server=localhost;Database=library;Uid=root;Pwd=" + pass + ";";

            MySQLReader(connectionStr);

            MySQLWriter(connectionStr);

            MySQLFinder(connectionStr, title);
        }
    }
}