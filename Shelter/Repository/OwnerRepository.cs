using Shelter.Data;
using Shelter.Interfaces;

namespace Shelter.Repository
{
    public class OwnerRepository : IOwner
    {
        private readonly DataContext _context;
        public OwnerRepository(DataContext context)
        {
            _context = context;
        }
    }
}
