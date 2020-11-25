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
        }
    }
}
