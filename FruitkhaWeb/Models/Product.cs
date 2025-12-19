using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitkhaWeb.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? SalePrice { get; set; }

        [StringLength(500)]
        public string? ImageUrl { get; set; }

        public int Stock { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        public bool IsNewProduct { get; set; } = false;

        public bool IsPromotional { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Foreign key
        public int CategoryId { get; set; }

        // Navigation property
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } = null!;

        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
