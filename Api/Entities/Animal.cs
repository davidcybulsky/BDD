using System.Text.Json.Serialization;

namespace Api.Entities
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Species Species { get; set; }
        public Enclosure Enclosure { get; set; }
        [JsonIgnore]
        public Caretaker Caretaker { get; set; }
        public Guid CaretakerId { get; set; }
    }
}
