// task 06: Create an Excel file with 2 columns: name and score:
// Write a program that reads your MS Excel file through the
// OLE DB data provider and displays the name and score row by row.

// task07: Implement appending new rows to the Excel file.

namespace _06.MSExel_And_OLEDB
{
    using System;
    using System.Data.OleDb;

    class MSExelAndOLEDB
    {
        private static void ExcelReader(string provider, string dataSource)
        {
            var oleDbConnection = new OleDbConnection(provider + dataSource);

            oleDbConnection.Open();
            using (oleDbConnection)
            {
                var oleDbCommand = new OleDbCommand("select * from [USers$]", oleDbConnection);

                OleDbDataReader reader = oleDbCommand.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = (string) reader["Name"];
                        double score = (double) reader["Score"];

                        Console.WriteLine("{0} has score: {1} points", name, score);
                    }
                }
                reader.Close();
            }
            oleDbConnection.Close();
        }

        public static void ExcelWriter(string provider, string dataSource)
        {
            var oleDbConnection = new OleDbConnection(provider + dataSource);

            oleDbConnection.Open();
            using (oleDbConnection)
            {
                var oleDbCommand = new OleDbCommand("INSERT INTO [USers$] ([Name], [Score])" +
                                                    "VALUES (@name, @score)", oleDbConnection);

                oleDbCommand.Parameters.AddWithValue("@name", "Ginka Gocheva");
                oleDbCommand.Parameters.AddWithValue("@score", 86);

                try
                {
                    oleDbCommand.ExecuteNonQuery();

                    Console.WriteLine("Row inserted successfully.");
                }
                catch (OleDbException exception)
                {
                    Console.WriteLine("SQL Error occured: " + exception);
                }
            }
            oleDbConnection.Close();
        }

        static void Main()
        {
            string provider = "Provider=Microsoft.ACE.OLEDB.12.0;";
            string dataSource = @"Data Source=..\..\NamesAndScores.xlsx;Extended Properties=""Excel 12.0 XML;HDR=Yes""";
            
            // Task 06
            ExcelReader(provider,dataSource);

            // Task 07
            ExcelWriter(provider, dataSource);
        }
    }
}