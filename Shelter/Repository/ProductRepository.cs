using Shelter.Data;
using Shelter.Interfaces;

namespace Shelter.Repository
{
    public class ProductRepository : IProduct
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
    }
}
