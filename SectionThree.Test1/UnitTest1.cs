using Moq;
using MSA.Phase2.AmazingApi.Controllers;
using MSA_Phase2_Backend.Data;
using MSA_Phase2_Backend.Models;
using Xunit;

namespace SectionThree.Test1
{
    [TestFixture]
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
                animal = new RandomAnimal();
                animalInfo = new AnimalRepository();
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
            public async Task GetAllAnimalssync_ShouldReturnAnimal_WhenAnimalExists()
            {
                //Arrange
                var list = new List<RandomAnimal> { };
                _animalRepoMock.Setup(x => x.getAllAnimal()).Returns(list);
                //Act
                var animals = animalInfo.getAllAnimal();
                //Assert
                Xunit.Assert.Equal(list, animals);
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
}