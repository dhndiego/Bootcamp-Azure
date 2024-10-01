using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet]
        [Route("GetWithAI")]
        public async Task<IActionResult> GetWithAI(string question)
        {
            var result = await _candidateService.ResponseWithAI(question);

            return Ok(result);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IList<Candidate> result = await _candidateService.GetAll();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _candidateService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Candidate candidate)
        {
            var result = await _candidateService.Create(candidate);

            return Ok(result);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> CreateWithBus([FromBody] Candidate candidate)
        {
            var result = await _candidateService.CreateWithBus(candidate);

            if (result)
            {
                return Ok("Candidato criado com sucesso!");
            } else { 
                return UnprocessableEntity("Candidato não cadastrado!");
            }
            
        }

        [HttpPost]
        [Route("RegisterWithAI")]
        public async Task<IActionResult> CreateWithAI()
        {
            var result = await _candidateService.CreateWithAI();

            return Ok(result);

        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            try
            {
                var result = await _candidateService.Delete(id);

                return Ok("Candidato removido com sucesso!");
            }
            catch (ApplicationException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Candidate candidate)
        {
            try
            {
                var result = await _candidateService.Update(candidate);

                return Ok("Candidato atualizado com sucesso!");
            }
            catch (ApplicationException e)
            {
                return UnprocessableEntity(e.Message);
            }
        }
    }
}
