// Re-implement the previous task with SQLite embedded DB (see http://sqlite.phxsoftware.com).

namespace _10.SQLite_Operations
{
    using System;
    using System.Data.SQLite;
    using System.Text;

    class SQLiteOperations
    {
        public static void MySQLReader(string connectionStr)
        {
            SQLiteConnection connection = new SQLiteConnection(connectionStr);
            connection.Open();
            using (connection)
            {
                SQLiteCommand command = new SQLiteCommand("select * from books", connection);
                SQLiteDataReader reader = command.ExecuteReader();
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
            SQLiteConnection connection = new SQLiteConnection(connectionStr);
            connection.Open();
            using (connection)
            {
                SQLiteCommand command = new SQLiteCommand("INSERT INTO books (Title, Author,PublishDate,ISBN) " +
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
            SQLiteConnection connection = new SQLiteConnection(connectionStr);
            connection.Open();
            using (connection)
            {
                SQLiteCommand command = new SQLiteCommand("select Title from books", connection);
                SQLiteDataReader reader = command.ExecuteReader();
                StringBuilder str = new StringBuilder();
                while (reader.Read())
                {
                    string titleDB = (string)reader[0];
                    if (title == titleDB)
                    {
                        str.AppendLine(" Title: " + reader[0] +" found");
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
