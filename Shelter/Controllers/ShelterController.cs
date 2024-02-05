using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Shelter.DTO;
using Shelter.Interfaces;
using Shelter.Migrations;
using Shelter.Models;

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
        public async Task<IActionResult> GetPetsInShelter(string shelterAddress)
        {
            if(await _shelterRepository.ShelterExists(shelterAddress))
                return NotFound("Shelter with this address do not exists");

            ICollection<PetDTO> PetsCollection = await _shelterRepository.PetsInShelter(shelterAddress);

            if (PetsCollection == null)
                return NotFound("No animals found");

            return Ok(PetsCollection);
        }

        [HttpGet("ProductsInShelter")]
        public async Task<IActionResult> GetProductsInShelter(string shelterAddress)
        {
            if (await _shelterRepository.ShelterExists(shelterAddress))
                return NotFound("Shelter with this address do not exists");

            ICollection<ProductsDTO> ProductCollection = _mapper.Map<ICollection<ProductsDTO>>(await _shelterRepository.ProductsInShelter(shelterAddress));

            if (ProductCollection == null)
                return NotFound("No products found");

            return Ok(ProductCollection);
        }

        [HttpPost]
        public async Task<IActionResult> AddPetToShelter(string name, int age, char gender, string kind, string breed, string shelterAddress)
        {
            if (await _shelterRepository.ShelterExists(shelterAddress))
                BadRequest("No shelters with this address");

            Models.PetShelter petShelter = await _shelterRepository.GetShelterByAddress(shelterAddress);

            Pet pet = new Pet()
            {
                Name = name,
                Age = age,
                Gender = gender,
                KindOfAnimal = kind,
                Breed = breed,
                PetShelter = petShelter
            };

            await _shelterRepository.AddPet(pet);
            await _shelterRepository.SaveChanges();
            return Ok("Data added successfully");
        }
    }
}
