using Api.Entities;

namespace Api.Interfaces
{
    public interface IExtendedAnimalService
    {
        Task<IEnumerable<Animal>> GetAnimalsBySpecies(Species species);
        Task<IEnumerable<Animal>> GetAnimalsByCaretakerId(int caretakerId);
        Task<IEnumerable<Animal>> GetAnimalsByEnclosure(Enclosure enclosure);
    }
}
