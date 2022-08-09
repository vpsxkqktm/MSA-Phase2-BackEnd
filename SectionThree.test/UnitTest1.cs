using Moq;
using MSA.Phase2.AmazingApi.Controllers;
using MSA_Phase2_Backend.Data;
using MSA_Phase2_Backend.Models;
using Xunit;

namespace SectionThree.test
{
    public class Tests
    {
        public class AnimalTests
        {
            //IAnimalRepository repository;
            //IHttpClientFactory clientFactory;
            private AnimalRepository animalInfo;
            private RandomAnimal animal;
            private readonly SectionOne _sut;
            private readonly Mock<IAnimalRepository> _animalRepoMock = new Mock<IAnimalRepository>();


            public AnimalTests()
            {
                _sut = new SectionOne(_animalRepoMock.Object);
            }
            /*
            [SetUp]
            public void Setup()
            {
                //ARRANGE
                animalInfo = new AnimalRepository();
                animal = new RandomAnimal();
            }
            */
            [Fact]
            public async Task GetByIdAsync_ShouldReturnAnimal_WhenAnimalExists()
            {
                //Arrange
                List<RandomAnimal> animals = new List<RandomAnimal>() { };

                //Act
                var animal = (Object)await _sut.GetAllAnimals();
                var anim = (List<RandomAnimal>)animal;
                _animalRepoMock.Setup(b => b.getAllAnimal()).Returns(animals);
                //Assert
                Assert.AreEqual(anim, animals);
            }
            /*
            public void CheckAnimal()
            {
                //ACT
                var anim = (Object)_sut.GetRandomAnimal();
                var anima = (RandomAnimal)anim;
                animal = animalInfo.getAnimal(anima.id);
                //ASSERT
                Assert.AreEqual(animal, anima);
            }*/
        }
    }