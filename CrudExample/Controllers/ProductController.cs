using CrudExample.Models;
using CrudExample.Models.Database;
using CrudExample.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CrudExample.Controllers
{
    public class ProductController : Controller
    {
        private readonly DatabaseConntext _context;
        public ProductController(DatabaseConntext context)
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
    }
}
