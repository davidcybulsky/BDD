using Api.Entities;

namespace Api.Interfaces
{
    public interface IExtendedAnimalService
    {
        Task<IEnumerable<Animal>> GetAnimalsBySpecies(Species species);
    }
}
