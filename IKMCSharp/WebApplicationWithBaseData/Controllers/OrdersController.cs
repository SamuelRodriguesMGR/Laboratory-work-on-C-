using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationWithBaseData.Models;

namespace WebApplicationWithBaseData.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ShopContext _context;

        public OrdersController(ShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
            .Include(o => o.Product)
            .ThenInclude(p => p.Category)
            .ToListAsync();
            return View(orders);
        }

        public IActionResult Create()
        {
            ViewBag.Products = _context.Products
                .Where(p => p.CategoryID != null) // только продукты с категорией
                .ToList();
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.OrderDate = DateTime.SpecifyKind(order.OrderDate, DateTimeKind.Utc);
                
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Products = _context.Products.ToList();
            return View(order);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();
            ViewBag.Products = _context.Products.ToList();
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Order order)
        {
            if (id != order.OrderID) return NotFound();

            if (ModelState.IsValid)
            {
                // Преобразуем дату в UTC перед сохранением
                order.OrderDate = DateTime.SpecifyKind(order.OrderDate, DateTimeKind.Utc);

                _context.Update(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Products = _context.Products.ToList();
            return View(order);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var order = await _context.Orders.Include(o => o.Product).FirstOrDefaultAsync(o => o.OrderID == id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}