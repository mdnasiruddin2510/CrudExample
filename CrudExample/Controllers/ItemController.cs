using CrudExample.Models;
using CrudExample.Models.Database;
using CrudExample.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudExample.Controllers
{
    public class ItemController : Controller
    {
        private readonly DatabaseConntext _context;
        public ItemController(DatabaseConntext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            ItemsVM model = new ItemsVM();
            ConfigureViewModel(model);
            return View(model);
        }
        public void ConfigureViewModel(ItemsVM model)
        {
            List<Category> CatList = _context.Categories.ToList();
            model.CategoryList = new SelectList(CatList, "Id", "Name");
        }
        [HttpPost]
        public IActionResult Create(List<ItemsVM> items)
        {

            //IEnumerable<Item> ItemList;

            List<Item> ItemList = new List<Item>();
            foreach (var model in items)
            {
                Item item = new Item();
                item.Code = model.Code;
                item.Name = model.Name;
                item.Price = model.Price;
                item.Description = model.Description;
                item.CategoryId = model.CategoryId;
                ItemList.Add(item);
               
            }
            _context.Items.AddRange(ItemList);
            int isAdded = _context.SaveChanges();
            if (isAdded>0)
            {
                return Json(ItemList);
            }
            return View();
        }
    }
}
