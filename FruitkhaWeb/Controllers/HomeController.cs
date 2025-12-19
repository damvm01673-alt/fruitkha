using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FruitkhaWeb.Models;
using FruitkhaWeb.Data;

namespace FruitkhaWeb.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Get categories for display
        var categories = await _context.Categories
            .Where(c => c.IsActive)
            .ToListAsync();

        // Get latest products (newest 6)
        var latestProducts = await _context.Products
            .Where(p => p.IsActive && p.IsNewProduct)
            .OrderByDescending(p => p.CreatedAt)
            .Take(6)
            .Include(p => p.Category)
            .ToListAsync();

        // Get promotional products (on sale)
        var promotionalProducts = await _context.Products
            .Where(p => p.IsActive && p.IsPromotional && p.SalePrice != null)
            .OrderByDescending(p => p.CreatedAt)
            .Take(6)
            .Include(p => p.Category)
            .ToListAsync();

        ViewBag.Categories = categories;
        ViewBag.LatestProducts = latestProducts;
        ViewBag.PromotionalProducts = promotionalProducts;

        return View();
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
