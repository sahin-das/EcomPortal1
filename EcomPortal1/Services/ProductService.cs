using EcomPortal.Models.Entities;
using EcomPortal.Models.Dtos.Product;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace EcomPortal.Services
{
    public class ProductService
    {
        private readonly ICrudRepository<Product> _productRepository;

        public ProductService(ICrudRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task<Product> CreateAsync(AddProductDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                Category = request.Category,
                Description = request.Description
            };

            return await _productRepository.AddAsync(product);
        }

        public async Task<Product> UpdateAsync(Guid id, UpdateProductDto request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {id} not found.");
            }

            product.Name = request.Name;
            product.Price = request.Price;
            product.Category = request.Category;
            product.Description = request.Description;

            return await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}