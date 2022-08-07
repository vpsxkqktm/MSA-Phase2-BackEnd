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
            _client = clientFactory.CreateClient("randAnimal");
        }

        /// <summary>
        /// Section posting action
        /// </summary>
        /// <returns>A 201 Created response</returns>
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<IActionResult> SectionOnePost()
        {
            RandomAnimal randAnimal;
            var res = await _client.GetAsync("x");

            randAnimal = await res.Content.ReadFromJsonAsync<RandomAnimal>();
            Console.WriteLine(res);
            randAnimals.Add(randAnimal);

            return Ok(randAnimal);
        }
        /// <summary>
        /// Multiplies two numbers together
        /// </summary>
        /// <param name="left">The number on the left, which must be a positive integer</param>
        /// <param name="right">The number on the right, which must be a positive integer</param>
        /// <returns>The muliple of the input numbers</returns>
        [HttpGet]
        [Route("Animal")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetMuliple()
        {
            return Ok(randAnimals);
        }

        /// <summary>
        /// SectionOne put action
        /// </summary>
        /// <returns>A 201 Created Response></returns>
        [HttpPut]
        [ProducesResponseType(201)]
        public IActionResult SectionOnePut()
        {
            Console.WriteLine("I'm over-writing whatever was there in the first place...");

            return Created(new Uri("https://www.aia.co.nz/en/index.html"), "AIA sponsors Tottenham!!");
        }

        /// <summary>
        /// Demonstrates a delete action
        /// </summary>
        /// <returns>A 204 No Content Response</returns>
        [HttpDelete]
        [ProducesResponseType(204)]
        public IActionResult DemonstrateDelete()
        {
            Console.WriteLine("I'm removing something from the database...");

            return NoContent();
        }
    }
}