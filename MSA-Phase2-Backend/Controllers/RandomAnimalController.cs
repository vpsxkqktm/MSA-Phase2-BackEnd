﻿using Microsoft.AspNetCore.Mvc;
using MSA_Phase3_Backend.Domain.Interfaces;
using MSA_Phase3_Backend.Domain.Models;
using System;

namespace MSA_Phase2_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomAnimalController: ControllerBase
    {

        private readonly IRandomAnimalServices _repository;
        private readonly HttpClient _client;

        public RandomAnimalController(IRandomAnimalServices repository, IHttpClientFactory clientFactory)
        {
            _repository = repository;
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("animals");
        }

        /// <summary>
        /// Get random animal from another API
        /// </summary>

        [HttpGet]
        [Route("RandAnimal")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<RandomAnimal>> GetRandomAnimal()
        {
            //RandomAnimal randAnimal;
            var res = await _client.GetAsync("rand");
            //var content = await res.Content.ReadAsStringAsync();
            //animals = await res.Content.ReadFromJsonAsync<RandomAnimal>();
            var result = await res.Content.ReadFromJsonAsync<RandomAnimal>();
            _repository.getRandAnimal(result);
            //randAnimals.Add(randAnimal);
            return Ok(result);
        }
    }
}
