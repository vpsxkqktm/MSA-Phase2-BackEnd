using Microsoft.AspNetCore.Mvc;
using MSA_Phase2_Backend.Data;
using MSA_Phase2_Backend.Model;
using System;



namespace MSA.Phase2.AmazingApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SectionOne : ControllerBase
    {
        private readonly IAnimalRepository _repository;
        private readonly HttpClient _client;

        /*private static List<RandomAnimal> randAnimals = new List<RandomAnimal>
        {
          new RandomAnimal
          {

          }
        };*/

        public SectionOne(IAnimalRepository repository, IHttpClientFactory clientFactory)
        { 
            _repository = repository;
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("animals");
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
            var animals = _repository.getAllAnimal();
            if (animals.Count == 0)
            {
                return BadRequest("animal not found.");
            }
            return Ok(animals);
        }

        /// <summary>
        /// Get random animal from another API
        /// </summary>
        /// 
        
        [HttpGet]
        [Route("RandAnimal")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<RandomAnimal>>> GetRandomAnimal()
        {
            //RandomAnimal randAnimal;
            var res = await _client.GetAsync("rand");
            var content = await res.Content.ReadAsStringAsync();
            //animals = await res.Content.ReadFromJsonAsync<RandomAnimal>();
            _repository.getRandAnimal(await res.Content.ReadFromJsonAsync<RandomAnimal>());
            //randAnimals.Add(randAnimal);
            return Ok(content);
        }

        
        
        /// <summary>
        /// Get animal from API
        /// </summary>
        [HttpGet]
        [Route("Animal")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IEnumerable<RandomAnimal>>> GetAnimal(int id)
        {

            var result = _repository.getAnimal(id);
            if (result.Count == 0)
            {
                return BadRequest("animal not found.");
            }
            return Ok(result);
        }
        
        /// <summary>
        /// Section posting action to add animals
        /// </summary>
        /// <returns>A 201 Created response</returns>
        
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<IEnumerable<RandomAnimal>>> SectionOnePost(RandomAnimal animal)
        {
            var result = _repository.sectionOnePost(animal);
            return Ok(result);
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
            

            return Ok(result.name + "has been deleted.");
        }
        
    }
        
}