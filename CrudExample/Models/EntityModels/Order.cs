namespace CrudExample.Models.EntityModels
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalItems { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }


    }
}
