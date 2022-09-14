using CrudExample.Models.EntityModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudExample.Models
{
    public class ItemsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        //public Category Category { get; set; }
        public int? CategoryId { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public SelectList CategoryList { get; set; }
        public ICollection<Item> ItemList { get; set; }
    }
}
