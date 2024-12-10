using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcomPortal.Models.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required, StringLength(100, ErrorMessage = "Product name must be between 1 and 100 characters.")]
        public string Name { get; set; }
        [StringLength(1000, ErrorMessage = "Description can't exceed 1000 characters.")]
        public string Description { get; set; }
        [Required, StringLength(50, ErrorMessage = "Category must be between 1 and 50 characters.")]
        public string Category { get; set; }
        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
