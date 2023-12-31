﻿using Api.Entities;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Services
{
    public class CaretakerService : ICaretakerService
    {
        private readonly SafariContext _dbcontext;

        public CaretakerService(SafariContext context)
        {
            _dbcontext = context;
        }

        public async Task Create(Caretaker caretaker)
        {
            await _dbcontext.AddRangeAsync(caretaker);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Caretaker> Delete(Guid id)
        {
            var caretaker = await _dbcontext.Caretakers.FirstOrDefaultAsync(x => x.Id == id);
            if (caretaker is not null)
            {
                _dbcontext.Caretakers.Remove(caretaker);
                await _dbcontext.SaveChangesAsync();
            }
            return caretaker;
        }

        public async Task<IEnumerable<Caretaker>> Read()
        {
            var caretakers = await _dbcontext.Caretakers.ToListAsync();
            return caretakers;
        }

        public async Task<Caretaker> ReadById(Guid id)
        {
            var caretaker = await _dbcontext.Caretakers.Include(c => c.Animals).FirstOrDefaultAsync(x => x.Id == id);

            return caretaker;
        }

        public async Task<Caretaker> Update(Guid id, Caretaker caretaker)
        {
            var caretakerInDb = await _dbcontext.Caretakers.FirstOrDefaultAsync(x => x.Id == id);
            if (caretakerInDb == null)
            {
                return null;
            }
            caretakerInDb.FirstName = caretaker.FirstName;
            caretakerInDb.LastName = caretaker.LastName;
            await _dbcontext.SaveChangesAsync();
            return caretakerInDb;
        }
    }
}
