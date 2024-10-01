using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperienceController : ControllerBase
    {
        private readonly IExperienceService _experienceService;

        public ExperienceController(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IList<Experience> result = await _experienceService.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetByCpf")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            var result = await _experienceService.GetByCpf(cpf);

            return Ok(result);
        }
    }
}
