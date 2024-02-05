using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Shelter.Data;
using Shelter.Interfaces;
using Shelter.Models;

namespace Shelter.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public async Task AddProductToShelter(string productName, string shelterAddress)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.Name == productName);
            PetShelter test = await _context.PetShelters.Include(x=>x.Products).FirstOrDefaultAsync(x => x.Address == shelterAddress);
            test.Products.Add(product);
        }

        public ValueTask<EntityEntry<Product>> AddProduct(Product product)
        {
            return _context.Products.AddAsync(product);
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
