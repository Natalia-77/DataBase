using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mybase
{
    class Program
    {
        static void Main(string[] args)
        {
            string str1 = "Data Source=nataliaserver.database.windows.net;Initial Catalog=Base;User ID=natalia;Password=Querty1*";
            Create c = new Create(str1);
            c.Procedure();

            //try
            //{
            //    SqlConnection conn = new SqlConnection(str);
            //    conn.Open();
            //    Console.WriteLine("Yes");
            //    string sql = File.ReadAllText("tblDepartments.sql");
            //    SqlCommand command = new SqlCommand(sql);
            //    command.Connection = conn;
            //    command.ExecuteNonQuery();
            //    Console.WriteLine("Запит tblDepartments.sql - виконано");

            //    //command.CommandText = File.ReadAllText("query\\tblProducts.sql");
            //    //command.ExecuteNonQuery();
            //    //Console.WriteLine("Запит tblProducts.sql - виконано");

            //    conn.Close();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error: " + ex.Message);
            //}
        }
    }
}
