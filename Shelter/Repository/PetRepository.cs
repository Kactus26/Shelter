using Shelter.Data;
using Shelter.Interfaces;

namespace Shelter.Repository
{
    public class PetRepository : IPet
    {
        private readonly DataContext _context;
        public PetRepository(DataContext context)
        {
            _context = context;
        }
    }
}
