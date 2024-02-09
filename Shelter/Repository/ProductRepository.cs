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
        public async Task AddProductToShelter(int productId, int shelterId)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            PetShelter test = await _context.PetShelters.Include(x=>x.Products).FirstOrDefaultAsync(x => x.Id == shelterId);
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
