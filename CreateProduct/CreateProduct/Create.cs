using System;
using System.Data.SqlClient;
using System.IO;


namespace CreateProduct
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
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

    }
}
