using CrudExample.Models;
using CrudExample.Models.Database;
using CrudExample.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CrudExample.Controllers
{
    public class OrderController : Controller
    {
        private readonly DatabaseConntext _context;
        public OrderController(DatabaseConntext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            OrderVM model = new OrderVM();
            ConfigureViewModel(model);
            return View(model);
        }
        public void ConfigureViewModel(OrderVM model)
        {
            var Items = _context.Items.ToList();
            model.ItemList = new SelectList(Items,"Id","Name");
        }
        [HttpPost]
        public IActionResult OrderSave(OrderVM model,List<OrderItemVM> itemList)
        {
            List<OrderItem> OIList = new List<OrderItem>();
            Order order = new Order();
            order.OrderNo = model.OrderNo;
            order.OrderDate = model.OrderDate;
            order.Customer = model.Customer;
            order.TotalPrice = 0;
            order.TotalItems = 0;
            _context.Orders.Add(order);
            _context.SaveChanges();
            var orderId = _context.Orders.OrderBy(c => c.Id).Select(x => x.Id).LastOrDefault();
            foreach (var item in itemList)
            {
                OrderItem obj = new OrderItem();
                obj.ItemId = item.ItemId;
                obj.Qty = item.Qty;
                obj.UnitPrice = item.UnitPrice;
                obj.OrderId = orderId;
                OIList.Add(obj);
            }
            _context.OrderItems.AddRange(OIList);
            bool isAdded = _context.SaveChanges() > 0;
            if (isAdded)
            {
                return Json(order);
            }
            return View();
        }
    }
}
