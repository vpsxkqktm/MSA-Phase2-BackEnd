using MSA_Phase2_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace MSA_Phase2_Backend.Data
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly RandomAnimalDbContext _context;

        public AnimalRepository(RandomAnimalDbContext context)
        {
            _context = context;
        }
        /*
        public static List<RandomAnimal> animals = new List<RandomAnimal>()
        {
            //For testing
            new RandomAnimal(){
                id= 0,
                name= "string",
                latine_name= "string",
                animal_type= "string",
                active_time= "string",
                length_min= 0,
                length_max= 0,
                weight_min= 0,
                weight_max= 0,
                lifespan= 0,
                habitat= "string",
                diet= "string",
                geo_range= "string",
                image_link= "string"
            }
        };
        */
        
        public async Task<IEnumerable<RandomAnimal>> getAllAnimal()
        {
            //_context.RandAnimal.
            return await _context.RandAnimal.OrderBy(a => a.id).ToListAsync();
        }
        
        public async Task<RandomAnimal> getRandAnimal(RandomAnimal animal)
        {
            //var content = await res.Content.ReadAsStringAsync();
            //var da = await data.Content.ReadFromJsonAsync<RandomAnimal>();
            await _context.RandAnimal.AddAsync(animal);
            _context.SaveChanges();
            //var result = (RandomAnimal)data;
            //animals.Add(result);
            return animal;
        }

        public async Task<RandomAnimal> getAnimal(int id)
        {
            //var result = animals.Find(a => a.id == id);
            //return result;
            return await _context.RandAnimal.FindAsync(id);
        }

        public async Task<RandomAnimal> sectionOnePost(RandomAnimal animal)
        {
            await _context.RandAnimal.AddAsync(animal);
            _context.SaveChanges();
            //animals.Add(animal);
            return animal;
        }
        public async Task<RandomAnimal> sectionOnePut(RandomAnimal request)
        {
            /*
            var animal = animals.Find(a => a.id == request.id);
            if (animal == null)
            {
                return null;
            }
            animal.name = request.name;
            animal.latine_name = request.latine_name;
            animal.animal_type = request.animal_type;
            animal.active_time = request.active_time;
            animal.length_min = request.length_min;
            animal.length_max = request.length_max;
            animal.weight_min = request.weight_min;
            animal.weight_max = request.weight_max;
            animal.lifespan = request.lifespan;
            animal.habitat = request.habitat;
            animal.diet = request.diet;
            animal.geo_range = request.geo_range;
            animal.image_link = request.image_link;
            */
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
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
    }}
