using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FruitkhaWeb.Models;

namespace FruitkhaWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Trái cây tươi", Description = "Các loại trái cây tươi ngon", IsActive = true },
                new Category { Id = 2, Name = "Trái cây nhập khẩu", Description = "Trái cây nhập khẩu chất lượng cao", IsActive = true },
                new Category { Id = 3, Name = "Trái cây sấy khô", Description = "Trái cây sấy khô giữ nguyên dinh dưỡng", IsActive = true },
                new Category { Id = 4, Name = "Nước ép trái cây", Description = "Nước ép tươi 100%", IsActive = true }
            );

            // Seed initial products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Dâu tây Đà Lạt", Description = "Dâu tây tươi từ Đà Lạt", Price = 85000, CategoryId = 1, Stock = 100, IsNewProduct = true, ImageUrl = "assets/img/products/product-img-1.jpg" },
                new Product { Id = 2, Name = "Táo Mỹ", Description = "Táo đỏ nhập khẩu từ Mỹ", Price = 120000, SalePrice = 99000, CategoryId = 2, Stock = 80, IsPromotional = true, ImageUrl = "assets/img/products/product-img-2.jpg" },
                new Product { Id = 3, Name = "Cam sành", Description = "Cam sành Việt Nam", Price = 45000, CategoryId = 1, Stock = 150, IsActive = true, ImageUrl = "assets/img/products/product-img-3.jpg" },
                new Product { Id = 4, Name = "Xoài cát Hòa Lộc", Description = "Xoài ngon nổi tiếng Tiền Giang", Price = 65000, CategoryId = 1, Stock = 90, IsNewProduct = true, ImageUrl = "assets/img/products/product-img-4.jpg" },
                new Product { Id = 5, Name = "Nho Úc", Description = "Nho không hạt nhập khẩu Úc", Price = 180000, SalePrice = 155000, CategoryId = 2, Stock = 60, IsPromotional = true, ImageUrl = "assets/img/products/product-img-5.jpg" },
                new Product { Id = 6, Name = "Thanh long ruột đỏ", Description = "Thanh long ruột đỏ Bình Thuận", Price = 35000, CategoryId = 1, Stock = 120, IsActive = true, ImageUrl = "assets/img/products/product-img-6.jpg" }
            );
        }
    }
}
