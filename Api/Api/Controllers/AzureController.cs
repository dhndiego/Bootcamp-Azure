using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureController : ControllerBase
    {
        private readonly IAzureService _azureService;

        public AzureController(IAzureService azureService)
        {
            _azureService = azureService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Candidate candidate)
        {
            var result = await _azureService.Create(candidate);

            if (result)
            {
                return Ok();
            }
            else
            {
                return UnprocessableEntity();
            }
        }

        


    }
}
