using EcomPortal.Models.Dtos.Order;
using EcomPortal.Services;
using System.Threading.Tasks;
using System;
using System.Web.Http;

namespace EcomPortal.Controllers
{
    public class OrderController : ApiController
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetOrderById(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateOrder([FromBody] AddOrderDto request)
        {
            var order = await _orderService.CreateAsync(request);
            return Ok(order);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateOrder(Guid id, [FromBody] UpdateOrderDto request)
        {
            var order = await _orderService.UpdateAsync(id, request);
            return Ok(order);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteOrder(Guid id)
        {
            try
            {
                await _orderService.DeleteAsync(id);
                return Ok("Deleted Successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
