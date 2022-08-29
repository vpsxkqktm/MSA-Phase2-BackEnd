using Microsoft.AspNetCore.Mvc;
using MSA_Phase3_Backend.Domain.Interfaces;
using MSA_Phase3_Backend.Domain.Models;
using System;



namespace MSA.Phase2.AmazingApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SectionOne : ControllerBase
    {
        private readonly IRandomAnimalServices _repository;

        /*private static List<RandomAnimal> randAnimals = new List<RandomAnimal>
        {
          new RandomAnimal
          {

          }
        };*/

        public SectionOne(IRandomAnimalServices repository)
        { 
            _repository = repository;
        }

        /// <summary />


        
        /// <summary>
        /// Using Dependency Injection to get all Animals
        /// </summary>
        [HttpGet]
        [Route("AllAnimal")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<RandomAnimal>>> GetAllAnimals()
        {
            //var res = await _client.GetAsync("rand");
            //var content = await res.Content.ReadAsStringAsync();
            //randAnimal = await res.Content.ReadFromJsonAsync<RandomAnimal>();
            //randAnimals.Add(randAnimal);
            var animals = await _repository.getAllAnimal();
            if (animals == null)
            {
                return BadRequest("animal not found.");
            }
            return Ok(animals);
        }
        
        

        
        
        /// <summary>
        /// Get animal from API
        /// </summary>
        [HttpGet("{id}")]
        [Route("Animal")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<RandomAnimal>> GetAnimal(int id)
        {

            var animal = await _repository.getAnimal(id);
            if (animal == null)
            {
                return BadRequest("animal not found.");
            }
            return Ok(animal);
        }
        
        /// <summary>
        /// Section posting action to add animals
        /// </summary>
        /// <returns>A 201 Created response</returns>
        
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<RandomAnimal>> SectionOnePost(RandomAnimal animal)
        {
            await _repository.sectionOnePost(animal);
            return CreatedAtAction(nameof(GetAnimal), new { id = animal.id }, animal);
        }
        


        
        /// <summary>
        /// SectionOne put action to update exist animal
        /// </summary>
        /// <returns>A 201 Created Response></returns>
        [HttpPut]
        [ProducesResponseType(201)]
        public async Task<ActionResult<IEnumerable<RandomAnimal>>> SectionOnePut(RandomAnimal request)
        {
            var result = _repository.sectionOnePut(request);
            if (result == null)
            {
                return BadRequest("animal does not exist");
            }

            return Ok(result);
        }
        
        /// <summary>
        /// Delete animal
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(204)]
        public async Task<ActionResult<List<RandomAnimal>>> DemonstrateDelete(int id)
        {
            var result = _repository.demonstrateDelete(id);
            
            if (result == null)
            {
                return BadRequest("animal not found.");
            }
            

            return Ok("the animal has been deleted.");
        }
        
    }
        
}