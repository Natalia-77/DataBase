using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProductsDB
{
    class TableAction
    {
        SqlConnection conn;
        string strconnect;

        public TableAction()
        {
            //strconnect = "Data Source=nataliaserver.database.windows.net;Initial Catalog=Product;User ID=natalia;Password=Querty1*";
            strconnect = "Data Source=serverpu816.database.windows.net;Initial Catalog=test;User ID=pu816;Password=Qwerty1*";
            conn = new SqlConnection(strconnect);
            conn.Open();
        }
          /// <summary>
          /// Show all
          /// </summary>
          /// <returns></returns>
        public List <Product>Show()
        {
            List<Product> product = new List<Product>();
            string query = "Select Id, ProductName, Price From Productes";
            SqlCommand command = new SqlCommand(query,conn);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    Product prod = new Product();
                    prod.Id = int.Parse(reader["Id"].ToString());
                    prod.ProductName = reader["ProductName"].ToString();
                    prod.Price =reader["Price"].ToString();
                    product.Add(prod);
                }
            }
            return product;
            
        }
        /// <summary>
        /// Added to base
        /// </summary>
        public void AddToTable()
        {
            Product p = new Product();
            Console.Write("Enter name of product: ");
            p.ProductName = Console.ReadLine();
            Console.Write("Enter price of product: ");
            p.Price = Console.ReadLine();

            string query = "INSERT INTO " +
               "dbo.Productes " +
               "(ProductName,Price) " +
               $"VALUES(" +
                       $"N'{p.ProductName}', " +
                       $"N'{p.Price}');";
            SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
           
        }

    }
}
