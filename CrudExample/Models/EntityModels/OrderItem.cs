namespace CrudExample.Models.EntityModels
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Item Item { get; set; }
        public int? ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Qty { get; set; }
        public decimal LineTotal { get; set; }
        public Order Order { get; set; }
        public int? OrderId { get; set; }
        //public string OrderNo { get; set; }
    }
}
