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

        public async Task<ICollection<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task AddProductToShelter(int productId, int shelterId)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
            PetShelter test = await _context.PetShelters.Include(x=>x.Products).FirstOrDefaultAsync(x => x.Id == shelterId);
            test.Products.Add(product);
        }
        public async Task<int> UpdateProductName(int productId, string newName)
        {
            return await _context.Products.Where(x => x.Id == productId).ExecuteUpdateAsync(x => x.SetProperty(c => c.Name, newName));
        }

        public ValueTask<EntityEntry<Product>> AddProduct(Product product)
        {
            return _context.Products.AddAsync(product);
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _context.Products.Include(x=>x.PetShelters).FirstOrDefaultAsync(x => x.Id == productId);
        }

        public async Task<EntityEntry<Product>> DeleteProduct(int productId)
        {
            return _context.Products.Remove(await _context.Products.FirstOrDefaultAsync(x => x.Id == productId));
        }

        public Task SaveChanges()
        {
            return _context.SaveChangesAsync();
        }
    }
}
