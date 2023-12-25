using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class ShoppingCarsController : Controller
    {
        private readonly WebshopContext _context;

        public ShoppingCarsController(WebshopContext context)
        {
            _context = context;
        }

        //add to cart
        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = _context.Product.Find(productId);

            if (product == null)
            {
                return NotFound();
            }

            var existingCartItem = _context.ShoppingCar.SingleOrDefault(
                sc => sc.ProductId == productId
            );

            if (existingCartItem != null)
            {
                existingCartItem.Quantity++;
            }
            else
            {
                var shoppingCartItem = new ShoppingCar
                {
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = 1,
                    ProductId = productId                 };

                _context.ShoppingCar.Add(shoppingCartItem);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Products");
        }



        // GET: ShoppingCars
        public async Task<IActionResult> Index()
        {
            var webshopContext = _context.ShoppingCar.Include(s => s.Product);
            return View(await webshopContext.ToListAsync());
        }

        // GET: ShoppingCars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShoppingCar == null)
            {
                return NotFound();
            }

            var shoppingCar = await _context.ShoppingCar
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.ShoppingCarId == id);
            if (shoppingCar == null)
            {
                return NotFound();
            }

            return View(shoppingCar);
        }

        
        // GET: ShoppingCars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShoppingCar == null)
            {
                return NotFound();
            }

            var shoppingCar = await _context.ShoppingCar
                .Include(s => s.Product)
                .FirstOrDefaultAsync(m => m.ShoppingCarId == id);
            if (shoppingCar == null)
            {
                return NotFound();
            }

            return View(shoppingCar);
        }

        // POST: ShoppingCars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShoppingCar == null)
            {
                return Problem("Entity set 'WebshopContext.ShoppingCar'  is null.");
            }
            var shoppingCar = await _context.ShoppingCar.FindAsync(id);
            if (shoppingCar != null)
            {
                _context.ShoppingCar.Remove(shoppingCar);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingCarExists(int id)
        {
            return (_context.ShoppingCar?.Any(e => e.ShoppingCarId == id)).GetValueOrDefault();
        }
    }
}
