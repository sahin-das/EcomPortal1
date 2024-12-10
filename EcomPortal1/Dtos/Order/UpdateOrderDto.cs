using EcomPortal.Models.Dtos.OrderProduct;
using System.Collections.Generic;

namespace EcomPortal.Models.Dtos.Order

{
    public class UpdateOrderDto
    {
        public List<OrderProductDto> OrderProducts { get; set; } = new List<OrderProductDto>();
    }
}

