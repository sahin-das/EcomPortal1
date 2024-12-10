using System;

namespace EcomPortal.Models.Dtos.OrderProduct
{

    public class OrderProductDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
