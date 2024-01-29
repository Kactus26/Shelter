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

        [HttpGet("PetsInShelter")]
        public async Task<IActionResult> GetPetsInShelter(string shelterAddres)
        {
            if(await _shelterRepository.ShelterExists(shelterAddres))
                return NotFound("Shelter with this addres do not exists");

            ICollection<PetDTO> PetsCollection = await _shelterRepository.PetsInShelter(shelterAddres);

            if (PetsCollection == null)
                return NotFound("No animals found");

            return Ok(PetsCollection);
        }

        [HttpGet("ProductsInShelter")]
        public async Task<IActionResult> GetProductsInShelter(string shelterAddres)
        {
            if (await _shelterRepository.ShelterExists(shelterAddres))
                return NotFound("Shelter with this addres do not exists");

            ICollection<ProductsDTO> ProductCollection = _mapper.Map<ICollection<ProductsDTO>>(await _shelterRepository.ProductsInShelter(shelterAddres));

            if (ProductCollection == null)
                return NotFound("No products found");

            return Ok(ProductCollection);
        }
    }
}
