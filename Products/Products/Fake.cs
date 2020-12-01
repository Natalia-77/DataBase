using Bogus;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    /// <summary>
    /// Class-helper for create data for database
    /// </summary>
    public class Fake
    {
        public int EmployeeId;
        public int ProductId;
        public int OrderId;

        List<Employeers> employee = new List<Employeers>();
        List<Products> product = new List<Products>();
        List<Orders> order = new List<Orders>();

        public Fake()
        {
            Randomizer.Seed = new Random();
           

            var empl = new Faker<Employeers>("uk")
                .RuleFor(x => x.Id, _ => ++EmployeeId)
                .RuleFor(x => x.Name, f => f.Name.FirstName())
                .RuleFor(x => x.City, f => f.Address.City());

            var prod = new Faker<Products>("uk")
                .RuleFor(x => x.Id, _ => ++ProductId)
                .RuleFor(x => x.ProductName, f => f.Commerce.ProductName())
                .RuleFor(x => x.Price, f => f.Finance.Amount());

            var ord = new Faker<Orders>("uk")
                .RuleFor(x => x.Id, _ => ++OrderId)
                .RuleFor(x => x.Number, f => f.Random.Number(1, 55))
                .RuleFor(x => x.EmployeersId, f => (EmployeeId > 0) ? f.Random.Number(1, EmployeeId) : 0)
                .RuleFor(x => x.ProductsId, f => (ProductId > 0) ? f.Random.Number(1, ProductId) : 0);


            for (int i = 0; i < 10; i++)
            {
                employee.Add(empl.Generate());
                product.Add(prod.Generate());
                order.Add(ord.Generate());
            }


        }
       
        public void Print()
        {
            foreach (var item in employee)
            {
                Console.WriteLine($"{ item.Id} {item.City} {item.Name}");
            }
            Console.WriteLine("--------------------------------\n");
            foreach (var item in product)
            {
                Console.WriteLine($"{ item.Id} {item.ProductName} {item.Price}");
            }
            Console.WriteLine("-----------------------------------\n");
            foreach (var item in order)
            {
                Console.WriteLine($"{ item.Id} {item.Number} {item.EmployeersId} {item.ProductsId}");
            }
        }

        
        

    }
}
