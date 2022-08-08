using Microsoft.AspNetCore.Mvc;
using System;



namespace MSA.Phase2.AmazingApi.Controllers
{   

    [ApiController]
    [Route("[controller]")]
    public class SectionOne : ControllerBase
    {
        
        private static List<RandomAnimal> randAnimals = new List<RandomAnimal>
        {
          new RandomAnimal
          {

          }
        };

        private readonly HttpClient _client;
        /// <summary />
        public SectionOne(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("animals");
        }

        /// <summary>
        /// Section posting action to add animals
        /// </summary>
        /// <returns>A 201 Created response</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<List<RandomAnimal>>> SectionOnePost(RandomAnimal animal)
        {
            randAnimals.Add(animal);

            return Ok(randAnimals);
        }
        /// <summary>
        /// Get random animal from another API
        /// </summary>
        [HttpGet]
        [Route("RandAnimal")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<RandomAnimal>>> GetRandomAnimal()
        {
            RandomAnimal randAnimal;
            var res = await _client.GetAsync("rand");
            //var content = await res.Content.ReadAsStringAsync();
            randAnimal = await res.Content.ReadFromJsonAsync<RandomAnimal>();
            randAnimals.Add(randAnimal);
            return Ok(randAnimal);
        }


        /// <summary>
        /// Get animal from API
        /// </summary>
        [HttpGet]
        [Route("Animal")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<RandomAnimal>>> GetAnimal(int id)
        {
            var animal = randAnimals.Find(a => a.id == id);
            if (animal == null)
            {
                return BadRequest("animal not found.");
            }
            return Ok(animal);
        }
        /// <summary>
        /// SectionOne put action to update exist animal
        /// </summary>
        /// <returns>A 201 Created Response></returns>
        [HttpPut]
        [ProducesResponseType(201)]
        public async Task<ActionResult<List<RandomAnimal>>> SectionOnePut(RandomAnimal request)
        {
            var animal = randAnimals.Find(a => a.id == request.id);
            if (animal == null)
            {
                return BadRequest("animal not found.");
            }
            animal.name = request.name;
            animal.latine_name = request.latine_name;
            animal.animal_type = request.animal_type;
            animal.active_time = request.active_time;
            animal.length_min = request.length_min;
            animal.length_max = request.length_max;
            animal.weight_min = request.weight_min;
            animal.weight_max = request.weight_max;
            animal.lifespan = request.lifespan;
            animal.habitat = request.habitat;
            animal.diet = request.diet;
            animal.geo_range = request.geo_range;
            animal.image_link = request.image_link;

            return Ok(randAnimals);
        }

        /// <summary>
        /// Delete animal
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(204)]
        public async Task<ActionResult<List<RandomAnimal>>> DemonstrateDelete(int id)
        {
            var animal = randAnimals.Find(a => a.id == id);
            if (animal == null)
            {
                return BadRequest("animal not found.");
            }
            randAnimals.Remove(animal);

            return Ok(animal);
        }
    }
}