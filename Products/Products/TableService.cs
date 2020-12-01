using Bogus;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;


namespace Products
{
    class TableService
    {

        SqlConnection _conn;
        string strconn;

        public TableService()
        {
            strconn = "Data Source = nataliaserver.database.windows.net; Initial Catalog = Product; User ID = natalia; Password = Querty1* ";
            _conn = new SqlConnection(strconn);          
        }

        /// <summary>
        /// Create table Products
        /// </summary>
        public void Create()
        {
            try
            {
                _conn.Open();

                string strread = File.ReadAllText("Createtbl.sql");
                SqlCommand command = new SqlCommand(strread);
                command.Connection = _conn;
                command.ExecuteNonQuery();
                //Console.WriteLine("ok");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
            finally
            {                
                _conn.Close();
            }


        }

        /// <summary>
        /// Select all Employyers Id in database
        /// </summary>
        /// <returns></returns>
        public List<int> GetIdList()
        {
            List<int> IdList = new List<int>();

            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();

            string query = "SELECT Id FROM Employeers";
            SqlCommand cmd = new SqlCommand(query, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    IdList.Add(reader.GetInt32(0));
                }
            }

            conn.Close();

            return IdList;
        }

        /// <summary>
        /// Select all Products Id in database
        /// </summary>
        /// <returns></returns>

        public List<int> GetIdListProd()
        {
            List<int> IdListProd = new List<int>();

            SqlConnection conn = new SqlConnection(strconn);
            conn.Open();

            string query = "SELECT Id FROM Products";
            SqlCommand cmd = new SqlCommand(query, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    IdListProd.Add(reader.GetInt32(0));
                }
            }

            conn.Close();

            return IdListProd;
        }

        public void Print()
        {
            List<int> ID = GetIdList();
            foreach (var item in ID)
            {
                Console.WriteLine(item);
            }
        }


        /// <summary>
        /// Add data to tables
        /// </summary>

        public void AddDataToTable()
        {
            _conn.Open();

            bool check = false;
            Random rand = new Random();

            List<Employeers> employee = new List<Employeers>();
            List<Products> product = new List<Products>();
            List<Orders> order = new List<Orders>();
            List<int> ID = GetIdList();
            List<int> IDProd = GetIdListProd();

            var empl = new Faker<Employeers>("uk")
               .RuleFor(x => x.Name, f => f.Name.FirstName())
               .RuleFor(x => x.City, f => f.Address.City());

            var prod = new Faker<Products>("uk")
                .RuleFor(x => x.ProductName, f => f.Commerce.ProductName())
                .RuleFor(x => x.Price, f => f.Finance.Amount());

            var ord = new Faker<Orders>("uk")
                .RuleFor(x => x.Number, f => f.Random.Number(1, 55))
                .RuleFor(x => x.EmployeersId, f => ID[rand.Next(0, ID.Count - 1)])
                .RuleFor(x => x.ProductsId, f => IDProd[rand.Next(0, IDProd.Count - 1)]);
                //.RuleFor(x => x.EmployeersId, f => f.Random.Number(16, 20))
                //.RuleFor(x => x.ProductsId, f => f.Random.Number(1, 5));


            for (int i = 0; i < 5; i++)
            {
                employee.Add(empl.Generate());
                product.Add(prod.Generate());
                order.Add(ord.Generate());
            }

            //foreach (var item in employee)
            //{

            //    string query = "INSERT INTO " +
            //   "Product.dbo.Employeers " +
            //   "(Name,City) " +
            //   $"VALUES(" +
            //           $"N'{item.Name}', " +
            //           $"N'{item.City}');";
            //    SqlCommand command = new SqlCommand(query, _conn);
            //    int result = command.ExecuteNonQuery();
            //    if (result > 0)
            //    {
            //        check = true;
            //    }
            //    else
            //    {
            //        check = false;
            //    }

            //}
            //if (check)
            //{
            //    Console.WriteLine("Succesfull added data's to database \"Product\" table Employeers ");
            //}

            //foreach (var item in product)
            //{

            //    string query = "INSERT INTO " +
            //   "Product.dbo.Products " +
            //   "(ProductName,Price) " +
            //   $"VALUES(" +
            //           $"N'{item.ProductName}', " +
            //           $"N'{item.Price}');";
            //    SqlCommand command = new SqlCommand(query, _conn);
            //    int result = command.ExecuteNonQuery();
            //    if (result > 0)
            //    {
            //        check = true;
            //    }
            //    else
            //    {
            //        check = false;
            //    }

            //}
            //if (check)
            //{
            //    Console.WriteLine("Succesfull added data's to database \"Product\" table Products ");
            //}

            foreach (var item in order)
            {

                string query = "INSERT INTO " +
               "Product.dbo.Orders " +
               "(Number,EmployeersId,ProductsId) " +
               $"VALUES(" +
                        $"N'{item.Number}', " +
                        $"N'{item.EmployeersId}', " +
                        $"N'{item.ProductsId}');";
                
                SqlCommand command = new SqlCommand(query, _conn);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    check = true;
                }
                else
                {
                    check = false;
                }

            }
            if (check)
            {
                Console.WriteLine("Succesfull added data's to database \"Product\" table Orders ");
            }


        }



    }
}
