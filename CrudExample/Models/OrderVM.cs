using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudExample.Models
{
    public class OrderVM
    {
        public int Id { get; set; }
        public string OrderNo { get; set; }
        public string Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalItems { get; set; }
        public decimal TotalPrice { get; set; }
        public int? ItemId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Qty { get; set; }
        public decimal LineTotal { get; set; }
        public SelectList ItemList { get; set; }
    }
}
