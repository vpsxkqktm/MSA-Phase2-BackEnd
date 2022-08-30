using Moq;
using MSA.Phase2.AmazingApi.Controllers;
using Xunit;
using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using MSA_Phase3_Backend.Domain.Models;
using MSA_Phase3_Backend.Domain.Interfaces;
using MSA_Phase2_Backend.Controllers;

namespace SectionThree.Test1
{
    [TestFixture]
    public class Tests
    {
        public class AnimalTests
        {
            private RandomAnimal animal;
            private RandomAnimal animal2;
            private readonly SectionOne _sut;
            private readonly Mock<IRandomAnimalServices> _animalServicesMock = new Mock<IRandomAnimalServices>();
            private readonly IFixture _fixture;

            public AnimalTests()
            {
                
                

                animal2 = new RandomAnimal
                {
                    id = 1,
                    name = "new Name",
                    latine_name = "string",
                    animal_type = "string",
                    active_time = "string",
                    length_min = 0,
                    length_max = 0,
                    weight_min = 0,
                    weight_max = 0,
                    lifespan = 0,
                    habitat = "string",
                    diet = "string",
                    geo_range = "string",
                    image_link = "string"
                };
                _fixture = new Fixture();
                _sut = new SectionOne(_animalServicesMock.Object);
            }

            [Fact]
            public async Task GetAnimalsAsync_ShouldReturnAnimalName()
            {
                //Arrange
                var testAnim = _fixture.Create<Task<RandomAnimal>>();
                _animalServicesMock.Setup(x => x.getAnimal(1)).Returns(testAnim);
                //Act
                var Aninm = await _sut.GetAnimal(1);
                var Animal = await _sut.GetAnimal(testAnim.Result.id = 1); ;
                var result = Aninm.Result.GetType().GetProperty("name");
                var testResult = Animal.Result.GetType().GetProperty("name");
                //Assert
                testResult.Should().BeSameAs(result);
            }
            
            [Fact]
            public async Task PostingRandomAnimalAsync_ReturnNewAnimalName()
            {
                //Arrange
                
                var testAnimal = _fixture.Create<Task<RandomAnimal>>();
                _animalServicesMock.Setup(x => x.getAnimal(1)).Returns(testAnimal);
                //Act
                animal = new RandomAnimal
                {
                    id = 2,
                    name = "new name",
                    latine_name = "string",
                    animal_type = "string",
                    active_time = "string",
                    length_min = 0,
                    length_max = 0,
                    weight_min = 0,
                    weight_max = 0,
                    lifespan = 0,
                    habitat = "string",
                    diet = "string",
                    geo_range = "string",
                    image_link = "string"
                };

                var posting = await _sut.SectionOnePost(animal);
                var result = posting.Result as CreatedAtActionResult;

                var final = (result.Value as RandomAnimal).name;
                //Assert
                final.Should().Be("new name");
            }

            
            [Fact]
            public async Task DeleteAnimalAsync_ShouldReturnAnimal_Not_Found()
            {
                //Arrange
                
                var testMock = _fixture.Create<Task<RandomAnimal>>();
                _animalServicesMock.Setup(x => x.demonstrateDelete(1)).Returns(testMock);

                //Act
                var checkAnimal = await _sut.GetAnimal(1);

                var result = (checkAnimal.Result as BadRequestObjectResult).Value;
                //Assert
                result.Should().Be("animal not found.");
            }
            
        }
    }
}