using MSA_Phase2_Backend.Model;

namespace MSA_Phase2_Backend.Data
{
    public interface IAnimalRepository
    {
        List<RandomAnimal> getAllAnimal();
        List<RandomAnimal> getRandAnimal(Object data);
        List<RandomAnimal> getAnimal(int id);
        List<RandomAnimal> sectionOnePost(RandomAnimal animal);
        RandomAnimal sectionOnePut(RandomAnimal request);
        RandomAnimal demonstrateDelete(int id);
    }
}