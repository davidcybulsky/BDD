namespace Api.Entities
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Species Species { get; set; }
        public Enclosure Enclosure { get; set; }
        public Caretaker Caretaker { get; set; }
    }
}
