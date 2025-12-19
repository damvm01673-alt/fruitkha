using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using FruitkhaWeb.Data;
using FruitkhaWeb.Models;
using FruitkhaWeb.Helpers;

namespace FruitkhaWeb.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string CartSessionKey = "ShoppingCart";

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders/Checkout
        public IActionResult Checkout()
        {
            var cart = GetCart();
            if (!cart.Any())
            {
                TempData["Error"] = "Giỏ hàng của bạn đang trống!";
                return RedirectToAction("Index", "Cart");
            }

            return View();
        }

        // POST: Orders/Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(Order order)
        {
            var cart = GetCart();
            if (!cart.Any())
            {
                TempData["Error"] = "Giỏ hàng của bạn đang trống!";
                return RedirectToAction("Index", "Cart");
            }

            // Get user ID
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            order.UserId = userId;
            order.OrderDate = DateTime.Now;
            order.Status = "Pending";

            // Calculate total
            decimal subtotal = cart.Sum(x => x.Subtotal);
            decimal shipping = subtotal >= 500000 ? 0 : 30000;
            order.TotalAmount = subtotal + shipping;

            // Create order items
            foreach (var cartItem in cart)
            {
                var product = await _context.Products.FindAsync(cartItem.ProductId);
                if (product != null)
                {
                    var orderItem = new OrderItem
                    {
                        ProductId = cartItem.ProductId,
                        Quantity = cartItem.Quantity,
                        UnitPrice = cartItem.Price,
                        Subtotal = cartItem.Subtotal
                    };
                    order.OrderItems.Add(orderItem);

                    // Update stock
                    product.Stock -= cartItem.Quantity;
                }
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // Clear cart
            HttpContext.Session.Remove(CartSessionKey);

            TempData["Success"] = "Đặt hàng thành công! Mã đơn hàng: " + order.Id;
            return RedirectToAction(nameof(Details), new { id = order.Id });
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            // Check if user owns this order
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (order.UserId != userId && !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            return View(order);
        }

        // GET: Orders/MyOrders
        public async Task<IActionResult> MyOrders()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _context.Orders
                .Where(o => o.UserId == userId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();

            return View(orders);
        }

        private List<CartItem> GetCart()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(CartSessionKey);
            return cart ?? new List<CartItem>();
        }
    }
}
