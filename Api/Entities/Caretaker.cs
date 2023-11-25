
namespace Api.Entities
{
    public class Caretaker
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Animal> Animals { get; set; }
    }
}
