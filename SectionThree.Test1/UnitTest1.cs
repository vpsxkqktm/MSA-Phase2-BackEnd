using Moq;
using MSA.Phase2.AmazingApi.Controllers;
using MSA_Phase2_Backend.Data;
using MSA_Phase2_Backend.Models;
using Xunit;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace SectionThree.Test1
{
    [TestFixture]
    public class Tests
    {
        public class AnimalTests
        {
            //IAnimalRepository repository;
            //IHttpClientFactory clientFactory;
            //private AnimalRepository animalInfo;
            private RandomAnimal animal;
            private readonly SectionOne _sut;
            private readonly Mock<IAnimalRepository> _animalRepoMock = new Mock<IAnimalRepository>();
            private readonly IFixture _fixture;

            public AnimalTests()
            {
                _sut = new SectionOne(_animalRepoMock.Object);
                animal = new RandomAnimal();
                _fixture = new Fixture();
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
            public async Task GetAllAnimalsAsync_ShouldReturnAnimal_WhenAnimalExists()
            {
                //Arrange
                var testAnim = _fixture.Create<Task<RandomAnimal>>();
                _animalRepoMock.Setup(x => x.getAnimal(1)).Returns(testAnim);
                //Act
                var Aninm = await _sut.GetAnimal(1);
                //Assert
                Xunit.Assert.NotNull(Aninm);
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