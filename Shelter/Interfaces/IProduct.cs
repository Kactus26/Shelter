using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shelter.Models;

namespace Shelter.Interfaces
{
    public interface IProduct
    {
        ValueTask<EntityEntry<Product>> AddProduct(Product product);
        Task<ICollection<Product>> GetAllProduct();
        Task AddProductToShelter(int productId, int shelterId);
        Task SaveChanges();
    }
}
