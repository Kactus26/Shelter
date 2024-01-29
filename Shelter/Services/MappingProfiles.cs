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

        }
    }
}
