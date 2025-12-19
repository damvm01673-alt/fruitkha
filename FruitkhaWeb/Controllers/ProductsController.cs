using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FruitkhaWeb.Data;
using FruitkhaWeb.Models;

namespace FruitkhaWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(int page = 1, int pageSize = 9)
        {
            var products = await _context.Products
                .Where(p => p.IsActive)
                .Include(p => p.Category)
                .OrderByDescending(p => p.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalProducts = await _context.Products.Where(p => p.IsActive).CountAsync();
            ViewBag.TotalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);
            ViewBag.CurrentPage = page;

            return View(products);
        }

        // GET: Products/Category/5
        public async Task<IActionResult> Category(int id, int page = 1, int pageSize = 9)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            ViewBag.CategoryName = category.Name;
            ViewBag.CategoryId = id;

            var products = await _context.Products
                .Where(p => p.IsActive && p.CategoryId == id)
                .Include(p => p.Category)
                .OrderByDescending(p => p.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalProducts = await _context.Products.Where(p => p.IsActive && p.CategoryId == id).CountAsync();
            ViewBag.TotalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);
            ViewBag.CurrentPage = page;

            return View("Index", products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            // Get related products from the same category
            var relatedProducts = await _context.Products
                .Where(p => p.IsActive && p.CategoryId == product.CategoryId && p.Id != product.Id)
                .Take(3)
                .ToListAsync();

            ViewBag.RelatedProducts = relatedProducts;

            return View(product);
        }

        // GET: Products/Search
        public async Task<IActionResult> Search(string keyword, int page = 1, int pageSize = 9)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Keyword = keyword;

            var products = await _context.Products
                .Where(p => p.IsActive && 
                       (p.Name.Contains(keyword) || p.Description.Contains(keyword)))
                .Include(p => p.Category)
                .OrderByDescending(p => p.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalProducts = await _context.Products
                .Where(p => p.IsActive && 
                       (p.Name.Contains(keyword) || p.Description.Contains(keyword)))
                .CountAsync();

            ViewBag.TotalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);
            ViewBag.CurrentPage = page;

            return View("Index", products);
        }
    }
}
