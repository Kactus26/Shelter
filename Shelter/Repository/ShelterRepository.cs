using Shelter.Data;
using Shelter.Interfaces;

namespace Shelter.Repository
{
    public class ShelterRepository : IShelter
    {
        private readonly DataContext _context;
        public ShelterRepository(DataContext context)
        {
            _context = context;
        }
    }
}
