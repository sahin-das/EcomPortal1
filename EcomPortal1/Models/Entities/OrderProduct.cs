using System;
using System.ComponentModel.DataAnnotations;

namespace EcomPortal.Models.Entities
{
    public class OrderProduct
    {
        [Key]
        public Guid OrderId { get; set; }
        [Key]
        public Guid ProductId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}