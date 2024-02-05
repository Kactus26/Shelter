using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shelter.Models;

namespace Shelter.Interfaces
{
    public interface IProduct
    {
        ValueTask<EntityEntry<Product>> AddProduct(Product product);
        Task AddProductToShelter(string productName, string shelterAddress);
        Task SaveChanges();
    }
}
