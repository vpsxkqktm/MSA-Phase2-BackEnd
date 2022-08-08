﻿using MSA_Phase2_Backend.Model;

namespace MSA_Phase2_Backend.Data
{
    public class AnimalRepository : IAnimalRepository
    {
        public static List<RandomAnimal> animals = new List<RandomAnimal>()
        {
            
        };


        public List<RandomAnimal> getAllAnimal()
        {
            return animals;
        }

        public List<RandomAnimal> getRandAnimal(Object data)
        {
            //var content = await res.Content.ReadAsStringAsync();
            //var da = await data.Content.ReadFromJsonAsync<RandomAnimal>();
            animals.Add((RandomAnimal)data);
            return animals;
        }

        public List<RandomAnimal> getAnimal(int id)
        {
            animals.Find(a => a.id == id);
            return animals;
        }

        public List<RandomAnimal> sectionOnePost(RandomAnimal animal)
        {
            animals.Add(animal);
            return animals;
        }
        public RandomAnimal sectionOnePut(RandomAnimal request)
        {
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
            return animal;
        }

        public RandomAnimal demonstrateDelete(int id)
        {
            var animal = animals.Find(a => a.id == id);
            if (animal == null)
            {
                return null;
            }
            animals.Remove(animal);
            return animal;
        }
    };
}