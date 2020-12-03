using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsDB
{
    class TableAction
    {
        SqlConnection conn;
        string strconnect;

        public TableAction()
        {
            strconnect = "Data Source=nataliaserver.database.windows.net;Initial Catalog=Product;User ID=natalia;Password=Querty1*";
            conn = new SqlConnection(strconnect);
        }
          
        public void Show()
        {
            List<Product> product = new List<Product>();
            string query = "Select Id, ProductName, Price From Products";


        }

    }
}
