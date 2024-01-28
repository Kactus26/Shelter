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

        [HttpGet("GetAllPets")]
        public async Task<IActionResult> GetPetShelters() 
        {
            ICollection<PetShelter> PetsSheltersCollection = await _shelterRepository.PetShelters();
            return Ok(PetsSheltersCollection);
        }

        [HttpGet("PetsInShelter")]
        public async Task<IActionResult> GetPetsInShelter(string shelterAddres)
        {
            if(await _shelterRepository.ShelterExists(shelterAddres))
                return NotFound("Shelter with this addres do not exists");

            ICollection<Pet> PetsCollection = await _shelterRepository.PetsInShelter(shelterAddres);
            
            if (PetsCollection == null)
                return NotFound("No animals found");

            return Ok(PetsCollection);
        }

        [HttpGet("ProductsInShelter")]
        public async Task<IActionResult> GetProductsInShelter(string shelterAddres)
        {
            if (await _shelterRepository.ShelterExists(shelterAddres))
                return NotFound("Shelter with this addres do not exists");

            ICollection<Product> ProductCollection = await _shelterRepository.ProductsInShelter(shelterAddres);

            if (ProductCollection == null)
                return NotFound("No products found");

            return Ok(ProductCollection);
        }
    }
}
