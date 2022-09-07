using Microsoft.EntityFrameworkCore;
using MSA_Phase3_Backend.Dal;
using MSA_Phase3_Backend.Domain.Interfaces;
using MSA_Phase3_Backend.Domain.Models;

namespace MSA_Phase3_Backend.Service
{
    public class RandomAnimalServices : IRandomAnimalServices
    {
        private readonly RandomAnimalDbContext _context;

        public RandomAnimalServices(RandomAnimalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RandomAnimal>> getAllAnimal()
        {
            return await _context.RandAnimal.OrderBy(a => a.id).ToListAsync();
        }

        public async Task<RandomAnimal> getRandAnimal(RandomAnimal animal)
        {
            await _context.RandAnimal.AddAsync(animal);
            _context.SaveChanges();
            return animal;
        }

        public async Task<RandomAnimal> getAnimal(int id)
        {
            return await _context.RandAnimal.FindAsync(id);
        }

        public async Task<RandomAnimal> sectionOnePost(RandomAnimal animal)
        {
            await _context.RandAnimal.AddAsync(animal);
            _context.SaveChanges();
            return animal;
        }
        public async Task<RandomAnimal> sectionOnePut(RandomAnimal request)
        {
            try
            {
                _context.Entry(request).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }


            return request;
        }

        public async Task<RandomAnimal> demonstrateDelete(int id)
        {
            var animal = await _context.RandAnimal.FindAsync(id);
            if (animal != null)
            {
                _context.RandAnimal.Remove(animal);
                await _context.SaveChangesAsync();
            }
            //animals.Remove(animal);
            return animal;
        }
    }
}
