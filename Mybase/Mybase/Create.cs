using System;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace Mybase
{
    class Create
    {
        private string strConnection;

        public Create()
        {
             strConnection= "Data Source=nataliaserver.database.windows.net;Initial Catalog=Base;User ID=natalia;Password=Querty1*";
           
        }

        public void Procedure()
        {          
           
            string[] files = System.IO.Directory.GetFiles(@"SQL");
            SqlConnection con = new SqlConnection(strConnection);

            try
            {
                    con.Open();
                    Console.WriteLine("It's ok-->>");
                    foreach (var item in files)
                    {
                        string sql = File.ReadAllText(item);
                        SqlCommand command = new SqlCommand(sql,con);
                        command.ExecuteNonQuery();
                    }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error-->>" + ex.Message);
            }
            finally
            {
                con.Close();
            }
            

        }


    }
}
