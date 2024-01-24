using Microsoft.AspNetCore.Mvc;
using Shelter.Interfaces;
using Shelter.Models;

namespace Shelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelterController : Controller
    {
        private readonly IPetShelter _shelterRepository;
        public ShelterController(IPetShelter shelter)
        {
            _shelterRepository = shelter;
        }

        [HttpGet]
        public async Task<IActionResult> Test() 
        {
            ICollection<PetShelter> test = await _shelterRepository.AllPets();
            return Ok(test);
        }
    }
}
