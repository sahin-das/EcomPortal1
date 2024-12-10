using EcomPortal.Models.Dtos.Product;
using EcomPortal.Services;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace EcomPortal1.Controllers
{
    public class ProductController : ApiController
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetProductById(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IHttpActionResult> CreateProduct(AddProductDto request)
        {
            var createdProduct = await _productService.CreateAsync(request);
            return Ok(createdProduct);
        }

        [HttpPut]
        public async Task<IHttpActionResult> UpdateProduct(Guid id, UpdateProductDto request)
        {
            var updatedProduct = await _productService.UpdateAsync(id, request);
            return Ok(updatedProduct);
        }

        [HttpDelete]
        public async Task<IHttpActionResult> DeleteProduct(Guid id)
        {
            try
            {
                await _productService.DeleteAsync(id);
                return Ok("Deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
