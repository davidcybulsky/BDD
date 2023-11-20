using Api.Entities;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly SafariContext _context;

        public AnimalService(SafariContext context)
        {
            _context = context;
        }

        public Task CreateAnimal(Animal animal)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAnimal(Guid id)
        {
            var animal = await _context.Animals.FirstOrDefaultAsync(a => a.Id == id);
            if (animal is not null)
            {
                _context.Remove(animal);
                await _context.SaveChangesAsync();
            }
        }

        public Task<Animal> GetAnimal()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Animal>> GetAnimals()
        {
            throw new NotImplementedException();
        }

        public Task UdateAnimal(Guid id, Animal animal)
        {
            throw new NotImplementedException();
        }
    }
}
