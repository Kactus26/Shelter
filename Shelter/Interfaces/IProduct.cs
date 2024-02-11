using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shelter.Models;

namespace Shelter.Interfaces
{
    public interface IProduct
    {
        ValueTask<EntityEntry<Product>> AddProduct(Product product);
        Task<int> UpdateProductName(int productId, string newName);
        Task<ICollection<Product>> GetAllProduct();
        Task<Product> GetProductById(int productId);
        Task<EntityEntry<Product>> DeleteProduct(int productId);
        Task AddProductToShelter(int productId, int shelterId);
        Task SaveChanges();
    }
}
