// Write a program that retrieves the images for all
// categories in the Northwind database and
// stores them as JPG files in the file system.

namespace _05.Retrieve_Northwind_Images
{
    using System;
    using System.Data.SqlClient;
    using System.IO;

    public class RetrieveNorthwindImages
    {
        private const string DestinationFileName =
        @"..\..\logo-from-db";

        public static void WriteToDisk(string imageFile, byte[] imgData)
        {
            FileStream stream = File.OpenWrite(imageFile);
            using (stream)
            {
                stream.Write(imgData, 0, imgData.Length);
            }
            stream.Close();
        }

        public static byte[] CorrectToJPG(byte[] imageBytes)
        {
            int len = imageBytes.Length;
            int header = 78;
            byte[] imgData = new byte[len - header];
            Array.Copy(imageBytes, 78, imgData, 0, len - header);

            return imgData;
        }

        private static void Main()
        {
            string server = "Server=.;";
            string database = "Database=Northwind;";
            string security = "Integrated Security=true";
            var dbConnection = new SqlConnection(server + " " + database + " " + security);

            dbConnection.Open();
            using (dbConnection)
            {
                SqlCommand dbCommand = new SqlCommand("SELECT Picture FROM Categories", dbConnection);

                SqlDataReader reader = dbCommand.ExecuteReader();
                using (reader)
                {
                    int imageCount = 1;

                    while (reader.Read())
                    {
                        var imageBytes = (byte[]) reader["Picture"];

                        byte[] imgData = CorrectToJPG(imageBytes);

                        string imageFile = DestinationFileName + imageCount + ".jpg";

                        WriteToDisk(imageFile, imgData);
                        
                        imageCount++;
                    }
                }
                reader.Close();
            }
            dbConnection.Close();
        }
    }
}
