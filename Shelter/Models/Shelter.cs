namespace Shelter.Models
{
    public class Shelter
    {
        public int Id { get; set; }
        public string Addres { get; set; }
        public ICollection<Pet> Pets { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
