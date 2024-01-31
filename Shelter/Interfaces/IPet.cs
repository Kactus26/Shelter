using Shelter.DTO;
using Shelter.Models;

namespace Shelter.Interfaces
{
    public interface IPet
    {
        Task<ICollection<Pet>> GetPetsWithoutOwner();
        Task<ICollection<Pet>> GetShelterPetsWithoutOwner(string address);
        Task<ICollection<Pet>> GetPetsWithBreed(string breed);
        Task<ICollection<PetDTO>> GetPetsWithKind(string kindOfAnimal);
        Task<ICollection<PetDTO>> GetAllPets();
        Task<bool> ShelterExists(string address);

    }
}
