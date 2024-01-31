using Shelter.DTO;
using Shelter.Models;

namespace Shelter.Interfaces
{
    public interface IPetShelter
    {
        Task<ICollection<PetShelter>> PetShelters(); 
        Task<ICollection<PetDTO>> PetsInShelter(string address);
        Task<ICollection<Product>> ProductsInShelter(string address);
        Task<bool> ShelterExists(string address);

    }
}
