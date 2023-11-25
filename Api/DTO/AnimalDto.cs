using Api.Entities;

namespace Api.DTO
{
    public class AnimalDto
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Species Species { get; set; }
        public Enclosure Enclosure { get; set; }
        public Guid CaretakerId { get; set; }
    }
}
