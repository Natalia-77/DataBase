
namespace Products
{
    /// <summary>
    /// Fields for table "Orders"
    /// </summary>
    public class Orders
    {
       //public int Id { get; set; }
        public int Number { get; set; }
        public int EmployeersId { get; set; }
        public int ProductesId { get; set; }

    }
}
