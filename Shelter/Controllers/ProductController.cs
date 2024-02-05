using Microsoft.AspNetCore.Mvc;
using Shelter.Interfaces;
using Shelter.Models;

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

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(string name, string description, float value)
        {
            Product product = new Product
            {
                Name = name,
                Description = description,
                Value = value
            };

            await _productRepository.AddProduct(product);
            await _productRepository.SaveChanges();
            return Ok("Data added successfully");
        }

        [HttpPost("AddProductToShelter")]
        public async Task<IActionResult> AddProductToShelter(string productName, string shelterAddress)
        {
            await _productRepository.AddProductToShelter(productName, shelterAddress);
            await _productRepository.SaveChanges();
            return Ok("Data added successfully");
        }
    }
}
