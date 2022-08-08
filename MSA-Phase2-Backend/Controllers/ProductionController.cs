using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MSA_Phase2_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionController : ControllerBase
    {
        private readonly HttpClient _client;
        /// <summary />
        public ProductionController(IHttpClientFactory clientFactory)
        {
            if (clientFactory is null)
            {
                throw new ArgumentNullException(nameof(clientFactory));
            }
            _client = clientFactory.CreateClient("Val");
        }
        [HttpGet]
        [Route("Production Get")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> GetGear()
        {
            var res = await _client.GetAsync("gear");
            //var content = await res.Content.ReadAsStringAsync();
            var content = await res.Content.ReadAsStringAsync();
            return Ok(content);
        }
    }
}
