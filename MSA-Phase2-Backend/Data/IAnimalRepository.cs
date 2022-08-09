using MSA_Phase2_Backend.Models;

namespace MSA_Phase2_Backend.Data
{
    public interface IAnimalRepository
    {
        List<RandomAnimal> getAllAnimal();
        RandomAnimal getRandAnimal(Object data);
        RandomAnimal getAnimal(int id);
        RandomAnimal sectionOnePost(RandomAnimal animal);
        RandomAnimal sectionOnePut(RandomAnimal request);
        RandomAnimal demonstrateDelete(int id);
    }
}