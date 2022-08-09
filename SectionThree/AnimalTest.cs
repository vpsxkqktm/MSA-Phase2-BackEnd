using Microsoft.AspNetCore.Mvc;
using Moq;
using MSA.Phase2.AmazingApi;
using MSA.Phase2.AmazingApi.Controllers;
using MSA_Phase2_Backend.Data;
using MSA_Phase2_Backend.Models;
using Xunit;

namespace SectionThree
{   
    
    public class AnimalTests
    {
        //IAnimalRepository repository;
        //IHttpClientFactory clientFactory;
        private AnimalRepository animalInfo;
        private RandomAnimal animal;
        private readonly SectionOne _sut;
        private readonly Mock<IAnimalRepository> _animalRepoMock = new Mock<IAnimalRepository>();
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock = new Mock<IHttpClientFactory>();


        public AnimalTests()
        {
            _sut = new SectionOne(_animalRepoMock.Object, _httpClientFactoryMock.Object);
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
            List<RandomAnimal> animals = new List<RandomAnimal>(){ };

            //Act
            var animal = (Object)await _sut.GetAnimal(0);
            var anim = (RandomAnimal)animal;
            _animalRepoMock.Setup(b => b.getAllAnimal()).Returns(animals);
            //Assert
            Assert.AreEqual(anim, (RandomAnimal)(Object)_sut.GetAnimal(0));
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