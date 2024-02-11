using Microsoft.AspNetCore.Mvc;
using Shelter.Interfaces;
using Shelter.Models;
using Shelter.Repository;

namespace Shelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProduct _productRepository;
        public ProductController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            ICollection<Product> product = await _productRepository.GetAllProduct();
            return Ok(product);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(string name, string description, string manufactorer, float value)
        {
            Product product = new Product
            {
                Name = name,
                Description = description,
                Manufacturer = manufactorer,
                Value = value
            };

            await _productRepository.AddProduct(product);
            await _productRepository.SaveChanges();
            return Ok("Data added successfully");
        }

        [HttpPost("AddProductToShelter")]
        public async Task<IActionResult> AddProductToShelter(int productId, int shelterId)
        {
            await _productRepository.AddProductToShelter(productId, shelterId);
            await _productRepository.SaveChanges();
            return Ok("Data added successfully");
        }

        [HttpPut("UpdateProductName")]
        public async Task<IActionResult> UpdateProductName(int productId, string newName)
        {
            int tablesChanged = await _productRepository.UpdateProductName(productId, newName);
            if (tablesChanged != 0)
                return Ok("Data updated successfully");
            else
                return NotFound("Pet not found");
        }

        [HttpDelete("DeleteProductFromShelter")]
        public async Task<IActionResult> DeleteProductFromShelter(int productId, int shelterId)
        {
            Product product = await _productRepository.GetProductById(productId);
            if (product == null)
                return NotFound("Product not found");

            if (!product.PetShelters.Remove(product.PetShelters.FirstOrDefault(x => x.Id == shelterId)))
                return NotFound("Shelter not found");

            await _productRepository.SaveChanges();
            return Ok("Data deleted successfully");
        }

        [HttpDelete("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            if (await _productRepository.GetProductById(productId) == null)
                return NotFound("Product not found");

            await _productRepository.DeleteProduct(productId);
            await _productRepository.SaveChanges();
            return Ok("Data deleted successfully");
        }
    }
}
