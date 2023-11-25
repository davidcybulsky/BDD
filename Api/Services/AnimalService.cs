using Api.Entities;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class AnimalService : IAnimalService, IExtendedAnimalService
    {
        private readonly SafariContext _context;

        public AnimalService(SafariContext context)
        {
            _context = context;
        }

        public async Task CreateAnimal(Animal animal)
        {
            await _context.AddAsync(animal);
            await _context.SaveChangesAsync();
        }

        public async Task<Animal> DeleteAnimal(Guid id)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);
            if (animal is not null)
            {
                _context.Remove(animal);
                await _context.SaveChangesAsync();
            }
            return animal;
        }

        public async Task<Animal> GetAnimal(Guid id)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(x => x.Id == id);
            return animal;
        }

        public async Task<ICollection<Animal>> GetAnimals()
        {
            var animals = await _context.Animals.ToListAsync();
            return animals;
        }

        public async Task<IEnumerable<Animal>> GetAnimalsByCaretakerId(Guid caretakerId)
        {
            var animals = await _context.Caretakers
                                .Include(x => x.Animals)
                                .Select(x => x.Animals)
                                .FirstAsync();
            return animals;
        }

        public async Task<IEnumerable<Animal>> GetAnimalsBySpecies(Species species)
        {
            var animals = await _context.Animals.Where(x => x.Species == species).ToListAsync();
            return animals;
        }

        public async Task UpdateAnimal(Guid id, Animal animal)
        {
            var animalInDb = await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);
            if (animalInDb is not null)
            {
                animalInDb.Name = animal.Name;
                animalInDb.Species = animal.Species;
                animalInDb.Enclosure = animal.Enclosure;
                animalInDb.Caretaker = animal.Caretaker;
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Animal>> GetAnimalsByEnclosure(Enclosure enclosure)
        {
            var animals = await _context.Animals.Where(x => x.Enclosure == enclosure).ToListAsync();
            return animals;
        }
    }
}
