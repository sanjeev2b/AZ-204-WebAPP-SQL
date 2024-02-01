namespace AZ_204_WebAPP_SQL.Models
{
    public class Product
    {

        public int ProductID { get; set; }
        public required string ProductName { get; set; }
        public int Quantity { get; set; }

    }
}
