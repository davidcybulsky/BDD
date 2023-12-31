﻿using Api.Entities;

namespace Api.Interfaces
{
    public interface IAnimalService
    {
        Task<Animal> GetAnimal(Guid id);
        Task<ICollection<Animal>> GetAnimals();
        Task CreateAnimal(Animal animal);
        Task UpdateAnimal(Guid id, Animal animal);
        Task<Animal> DeleteAnimal(Guid id);

        Task<IEnumerable<Animal>> GetAnimalsBySpecies(Species species);
        Task<IEnumerable<Animal>> GetAnimalsByCaretakerId(Guid caretakerId);
        Task<IEnumerable<Animal>> GetAnimalsByEnclosure(Enclosure enclosure);


    }
}
