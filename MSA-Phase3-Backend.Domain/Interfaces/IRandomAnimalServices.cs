using MSA_Phase3_Backend.Domain.Models;

namespace MSA_Phase3_Backend.Domain.Interfaces
{
    public interface IRandomAnimalServices
    {
        public Task<IEnumerable<RandomAnimal>> getAllAnimal();
        public Task<RandomAnimal> getRandAnimal(RandomAnimal data);
        public Task<RandomAnimal> getAnimal(int id);
        public Task<RandomAnimal> sectionOnePost(RandomAnimal animal);
        public Task<RandomAnimal> sectionOnePut(RandomAnimal request);
        public Task<RandomAnimal> demonstrateDelete(int id);
    }
}
