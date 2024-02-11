using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shelter.DTO;
using Shelter.Interfaces;
using Shelter.Migrations;
using Shelter.Models;
using Shelter.Repository;

namespace Shelter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelterController : Controller
    {
        private readonly IPetShelter _shelterRepository;
        private readonly IMapper _mapper;
        public ShelterController(IPetShelter shelter, IMapper mapper)
        {
            _shelterRepository = shelter;
            _mapper = mapper;
        }

        [HttpGet("GetAllPetShelters")]
        public async Task<IActionResult> GetPetShelters()
        {
            ICollection<Models.PetShelter> PetsSheltersCollection = await _shelterRepository.PetShelters();
            ICollection<PetShelterDTO> DTOs = _mapper.Map<List<PetShelterDTO>>(PetsSheltersCollection);
            return Ok(DTOs);
        }

        [HttpGet("GetPetsInShelter")]
        public async Task<IActionResult> GetPetsInShelter(int shelterId)
        {
            if (await _shelterRepository.ShelterExists(shelterId))
                return NotFound("Shelter with this id doesn't exist");

            ICollection<PetDTO> PetsCollection = await _shelterRepository.PetsInShelter(shelterId);

            if (PetsCollection == null)
                return NotFound("No animals found");

            return Ok(PetsCollection);
        }

        [HttpGet("ProductsInShelter")]
        public async Task<IActionResult> GetProductsInShelter(int shelterId)
        {
            if (await _shelterRepository.ShelterExists(shelterId))
                return NotFound("Shelter with this id doesn't exist");

            ICollection<ProductsDTO> ProductCollection = _mapper.Map<ICollection<ProductsDTO>>(await _shelterRepository.ProductsInShelter(shelterId));

            if (ProductCollection == null)
                return NotFound("No products found");

            return Ok(ProductCollection);
        }

        [HttpPost("AddPetShelter")]
        public async Task<IActionResult> AddPetShelter(string address)
        {
            PetShelter petShelter = new PetShelter
            {
                Address = address
            };

            await _shelterRepository.AddPetShelter(petShelter);
            await _shelterRepository.SaveChanges();
            return Ok("Data added successfully");
        }

        [HttpPut("MovePet")]
        public async Task<IActionResult> UpdateShelterForPet(int petId, int newShelterId)
        {
            PetShelter petShelter = await _shelterRepository.GetShelterById(newShelterId);
            if (petShelter == null)
                NotFound("Pet shelter with this id doesn't exist");

            Pet pet = await _shelterRepository.GetPetById(petId);
            if (pet == null)
                NotFound("Pet with this id doesn't exist");

            pet.PetShelter = petShelter;
            await _shelterRepository.SaveChanges();
            return Ok("Data changed successfully");
        }

        /*[HttpDelete("DeleteShelter")]
        public async Task<IActionResult> DeleteShelter(int shelterId)
        {
            if (await _shelterRepository.GetShelterById(shelterId) == null)
                return NotFound("Shelter not found");

            await _shelterRepository.DeleteShelter(shelterId);
            await _shelterRepository.SaveChanges();

            return Ok("Data deleted successfully");
        }*ErrorErrorErrorErrorErrorErrorErrorError/
    }
}
