namespace Shelter.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Address { get; set; }
        public ICollection<Pet>? Pets { get; set; }
    }
}
