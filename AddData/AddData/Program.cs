using System;
using System.Data.SqlClient;
using System.IO;


namespace AddData
{
    class Program
    {
        static void Main(string[] args)
        {
            string strConnection = "Data Source = nataliaserver.database.windows.net; Initial Catalog = Base; User ID = natalia; Password = Querty1*";

            try
            {
                SqlConnection conn = new SqlConnection(strConnection);
                conn.Open();
                string sql = File.ReadAllText("AddData.sql");
                SqlCommand command = new SqlCommand(sql);
                command.Connection = conn;
                command.ExecuteNonQuery();
                Console.WriteLine("It's ok-->>--");
                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something wrong-->> " + ex.Message);
            }

        }
    }
}
