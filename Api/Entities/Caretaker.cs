namespace Api.Entities
{
    public class Caretaker
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
