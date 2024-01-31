namespace Shelter.Models
{
    public class PetShelter
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public ICollection<Pet>? Pets { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
