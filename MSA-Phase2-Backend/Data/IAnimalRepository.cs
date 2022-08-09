using MSA_Phase2_Backend.Models;

namespace MSA_Phase2_Backend.Data
{
    public interface IAnimalRepository
    {
        public Task<IEnumerable<RandomAnimal>> getAllAnimal();
        public Task<RandomAnimal> getRandAnimal(RandomAnimal data);
        public Task<RandomAnimal> getAnimal(int id);
        public Task<RandomAnimal> sectionOnePost(RandomAnimal animal);
        public Task<RandomAnimal> sectionOnePut(RandomAnimal request);
        public Task<RandomAnimal> demonstrateDelete(int id);
    }
}