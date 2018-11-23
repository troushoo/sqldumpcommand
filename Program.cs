using System;
using System.Data.SqlClient;

namespace sqlcommand
{
    class Program
    {
        static void Main(string[] args)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = "Data Source=localhost;Initial Catalog=testdb;Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            try
            {
                cnn.Open();
                string sqlquery = "SELECT * FROM mytable";

                SqlCommand command = new SqlCommand(sqlquery, cnn);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Console.WriteLine(dataReader.GetValue(0).ToString() + " " + dataReader.GetValue(1).ToString() + " " + dataReader.GetValue(2).ToString());
                }

                dataReader.Close();
                command.Dispose();
                System.Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot open connection");
            }

            cnn.Close();
        }
    }
}
