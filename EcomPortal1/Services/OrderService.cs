using EcomPortal.Models.Entities;
using EcomPortal.Models.Dtos.Order;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace EcomPortal.Services
{
    public class OrderService
    {
        private readonly ICrudRepository<Order> _orderRepository;
        private readonly ICrudRepository<Product> _productRepository;
        private readonly ICrudRepository<User> _userRepository;
        private readonly ICrudRepository<OrderProduct> _orderProductRepository;

        public OrderService(
            ICrudRepository<Order> orderRepository,
            ICrudRepository<Product> productRepository,
            ICrudRepository<User> userRepository,
            ICrudRepository<OrderProduct> orderProductRepository)
        { 
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _orderProductRepository = orderProductRepository;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _orderRepository.GetAllAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<Order> CreateAsync(AddOrderDto dto)
        {
            if(dto == null) 
            {  
                throw new ArgumentNullException(nameof(dto));
            }
            var user = await _userRepository.GetByIdAsync(dto.UserId) ??
                throw new ArgumentException($"User with ID {dto.UserId} not found.");
            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                OrderProducts = new List<OrderProduct>()
            };

            foreach (var productDto in dto.OrderProducts)
            {
                var product = await _productRepository.GetByIdAsync(productDto.ProductId) ??
                    throw new ArgumentException($"Product with ID {productDto.ProductId} not found.");
                var orderProduct = new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = productDto.Quantity
                };
                order.OrderProducts.Add(orderProduct);
            }
            await _orderRepository.AddAsync(order);
            return order;
        }

        public async Task<Order> UpdateAsync(Guid id, UpdateOrderDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            var order = await _orderRepository.GetByIdAsync(id) ??
                throw new KeyNotFoundException($"Order with ID {id} not found.");
            order.OrderProducts.Clear();
            foreach (var productDto in dto.OrderProducts)
            {
                var product = await _productRepository.GetByIdAsync(productDto.ProductId) ??
                    throw new ArgumentException($"Product with ID {productDto.ProductId} not found.");
                var orderProduct = new OrderProduct
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    Quantity = productDto.Quantity
                };
                order.OrderProducts.Add(orderProduct);
            }

            return await _orderRepository.UpdateAsync(order);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _orderRepository.DeleteAsync(id);
        }
    }
}