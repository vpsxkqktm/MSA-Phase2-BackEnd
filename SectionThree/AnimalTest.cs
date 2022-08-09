using Microsoft.AspNetCore.Mvc;
using MSA.Phase2.AmazingApi;
using MSA.Phase2.AmazingApi.Controllers;
using MSA_Phase2_Backend.Data;
using MSA_Phase2_Backend.Models;

namespace SectionThree
{   
    
    public class AnimalTests
    {

        private AnimalRepository animalInfo;
        private RandomAnimal animal;

        [SetUp]
        public void Setup()
        {
            //ARRANGE
            animalInfo = new AnimalRepository();
            animal = new RandomAnimal();
        }

        [Test]
        public void CheckAnimal()
        {
            //ACT
            animal = animalInfo.getRandAnimal(3);
            //ASSERT
            Assert.Pass();
        }
    }
}