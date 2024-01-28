using Shelter.Models;

namespace Shelter.Interfaces
{
    public interface IPetShelter
    {
        Task<ICollection<PetShelter>> PetShelters(); 
        Task<ICollection<Pet>> PetsInShelter(string addres);
        Task<ICollection<Product>> ProductsInShelter(string addres);
        Task<bool> ShelterExists(string addres);

    }
}
