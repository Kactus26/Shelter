namespace Shelter.DTO
{
    public class ProductsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Value { get; set; }
        public ICollection<PetShelterDTO>? PetShelters { get; set; }
    }
}
