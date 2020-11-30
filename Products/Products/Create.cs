using System;
using System.Data.SqlClient;
using System.IO;


namespace Products
{
    class Create
    {
        private string strConnection;

        public Create()
        {
            strConnection = "Data Source=nataliaserver.database.windows.net;Initial Catalog=Product;User ID=natalia;Password=Querty1*";
        }

        public void Connect()
        {
            SqlConnection conn = new SqlConnection(strConnection);

            try
            {
                conn.Open();
              
                string strread = File.ReadAllText("Createtbl.sql");
                SqlCommand command = new SqlCommand(strread);
                command.Connection = conn;
                command.ExecuteNonQuery();
                


            }
            catch(Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public void Add(Employeers employ)
        {
            string query = "INSERT INTO " +
                "dbo.Employeers " +
                "(Name,City) " +
                $"VALUES(" +
                        $"N'{employ.Name}', " +
                        $"N'{employ.City}');";
            SqlCommand command = new SqlCommand(query, conn);
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Успішно додано в БД");
            }
            else
            {
                Console.WriteLine("Виникли проблеми при додаванні");
            }
        }
    }
}
