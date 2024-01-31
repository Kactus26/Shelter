using AutoMapper;
using Shelter.DTO;
using Shelter.Migrations;

namespace Shelter.Services
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Models.PetShelter, PetShelterDTO>();
            CreateMap<Models.Pet, PetDTO>();
            CreateMap<Models.Product, ProductsDTO>();
            CreateMap<Models.Pet, PetWhithPetShelterDTO>(); 
            CreateMap<Models.Pet, PetWhithOwnerAndShelterDTO>();
        }
    }
}
