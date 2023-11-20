using Api.Entities;

namespace Api.Interfaces
{
    public interface IAnimalService
    {
        Task<Animal> GetAnimal();
        Task<ICollection<Animal>> GetAnimals();
        Task CreateAnimal(Animal animal);
        Task UdateAnimal(Guid id, Animal animal);
        Task DeleteAnimal(Guid id);
    }
}
