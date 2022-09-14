namespace CrudExample.Models
{
    public class OrderItemVM
    {
        public int? ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Qty { get; set; }
        public decimal LineTotal { get; set; }
    }
}
