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

        /// <summary>
        /// Update table
        /// </summary>
        /// <param name="id"></param>
        public void Update(int id )
        {
            Product pr = new Product();
            string query = "  UPDATE dbo.Productes " +
                $"";
            bool isBegin = true;

            Console.WriteLine("Enter name:");
            pr.ProductName = Console.ReadLine();

            if (!string.IsNullOrEmpty(pr.ProductName))
            {
                isBegin = false;
                query += $"SET ProductName = N'{pr.ProductName}' ";
            }
            else
            {               

                Console.WriteLine("Are you sure? Press '2' and go to next field");
                Console.WriteLine("Or press '1' and enter data in this field");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Enter name:");
                    pr.ProductName = Console.ReadLine();                   
                    query += $"SET ProductName = N'{pr.ProductName}' ";
                    isBegin = false;
                }
                else
                {
                    isBegin = true;
                }

            }

            Console.WriteLine("Enter price:");
            pr.Price = Console.ReadLine();

            if (!string.IsNullOrEmpty(pr.Price))
            {
                if (isBegin)
                {
                    query += "SET ";
                    isBegin = false;
                }
                else
                {
                    query += ", ";
                }
                query += $"[Price] = N'{pr.Price}'";
            }
            else
            {

                Console.WriteLine("Are you sure? Press '2' and go to next field");
                Console.WriteLine("Or press '1' and enter data in this field");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Enter price:");
                    pr.Price = Console.ReadLine();
                    query += $"SET Price = N'{pr.Price}' ";
                    isBegin = false;
                }
                else
                {
                    isBegin = true;
                }
            }            

            query += $" WHERE Id = {id} ; ";
            SqlCommand command = new SqlCommand(query, conn);
            command.ExecuteNonQuery();
        }

        /// <summary>
        /// Found in table from Name
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public List<Product> Found(Search search)
        {
            List<Product> listproducts = new List<Product>();

            string query2 = "Select Id, ProductName,Price " +
                "From Productes";
              bool isBegin = true;

                if (!string.IsNullOrEmpty(search.ProductName))
                {
                    isBegin = false;
                    query2 += $" WHERE ProductName LIKE N'%{search.ProductName}%'";
                }            
            
            SqlCommand command = new SqlCommand(query2, conn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product prod = new Product();
                    prod.Id = int.Parse(reader["Id"].ToString());
                    prod.ProductName = reader["ProductName"].ToString();
                    prod.Price = reader["Price"].ToString();
                    
                    listproducts.Add(prod);
                }
            }
            if(listproducts.Count==0)
            {
                Console.WriteLine("No result to data with these name!");
            }
            return listproducts;
        }

        /// <summary>
        /// Delete from table to Id column
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            string query3 = "DELETE FROM Productes " +
                $"WHERE Id = {id}; ";
            SqlCommand command = new SqlCommand(query3, conn);
            int res=command.ExecuteNonQuery();
            if (res==0)
            {
                Console.WriteLine("No data with that Id to delete");
            }
            else
            {
                Console.WriteLine("Succesfull delete!");
            }
        }


    }
}
