using Application.Services.Interfaces;
using Domain.Dto;
using Domain.Interfaces.Interfaces;
using Domain.Interfaces.Repository.Base;
using Domain.Models;
using Domain.Services;
using Infrastructure.Utils;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Application.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IUnitOfWorkBootcamp _unitOfWorkBootcamp;
        private readonly IServiceBus _serviceBus;
        private readonly IAzureOpenAI _azureOpenAI;
        private readonly IConfiguration _configuration;

        public CandidateService(IConfiguration configuration, IUnitOfWorkBootcamp unitOfWorkBootcamp, IServiceBus serviceBus, IAzureOpenAI azureOpenAI)
        {
            _unitOfWorkBootcamp = unitOfWorkBootcamp;
            _serviceBus = serviceBus;
            _azureOpenAI = azureOpenAI;
            _configuration = configuration;
        }

        public async Task<OpenAiResponse> ResponseWithAI(string question)
        {
            return await _azureOpenAI.AskToAI(_configuration["DataInfo:PdfAzure"], question);
        }

        public async Task<bool> CreateWithBus(Candidate candidate)
        {
            try
            {
                await _serviceBus.SendMessage("register", JsonConvert.SerializeObject(candidate));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CandidateDto> CreateWithAI()
        {
            var commandExperience = _configuration["CommandAI:GetExperience:Command1"]
                + _configuration["CommandAI:GetExperience:Command2"]
                + _configuration["CommandAI:GetExperience:Command3"]
                + _configuration["CommandAI:GetExperience:Command4"]
                + _configuration["CommandAI:GetExperience:Command5"]
                + _configuration["CommandAI:GetExperience:Command6"]
                + _configuration["CommandAI:GetExperience:Command7"];

            var responseAIName = await _azureOpenAI.AskToAI(_configuration["DataInfo:PdfCv"], _configuration["CommandAI:GetName"]);
            var responseAIemail = await _azureOpenAI.AskToAI(_configuration["DataInfo:PdfCv"], _configuration["CommandAI:GetEmail"]);
            var responseAICpf = await _azureOpenAI.AskToAI(_configuration["DataInfo:PdfCv"], _configuration["CommandAI:GetCpf"]);
            var responseAIBirthDate = await _azureOpenAI.AskToAI(_configuration["DataInfo:PdfCv"], _configuration["CommandAI:GetBirthDate"]);
            var responseAIExperience = await _azureOpenAI.AskToAI(_configuration["DataInfo:PdfCv"], commandExperience);

            var candidate = new CandidateDto
            {
                Name = FormatAI.FormatName(responseAIName.TextContent),
                Email = FormatAI.FormatEmail(responseAIemail.TextContent),
                Cpf = FormatAI.FormatCpf(responseAICpf.TextContent),
                BirthDate = FormatAI.FormatDate(responseAIBirthDate.TextContent),
                Experience = JsonConvert.DeserializeObject<List<ExperienceDto>>(responseAIExperience.TextContent)
            };

            return candidate;

        }

        public async Task<Guid> Create(Candidate candidate)
        {
            return await _unitOfWorkBootcamp.Candidate.Insert(candidate);
        }       

        public async Task<bool> Delete(Guid id)
        {
            var candidateUpdated = await GetById(id);

            if (candidateUpdated == null)
                throw new ApplicationException("Candidato não encontrado!");

            return await _unitOfWorkBootcamp.Candidate.Delete(id);            
        }

        public async Task<bool> Update(Candidate candidate)
        {
            var candidateUpdated = await GetById(candidate.Id);

            if(candidateUpdated == null)
                throw new ApplicationException("Candidato não encontrado!");

            return await _unitOfWorkBootcamp.Candidate.Update(candidate);
        }
        public async Task<IList<Candidate>> GetAll()
        {
            return await _unitOfWorkBootcamp.Candidate.GetAll();
        }
        public async Task<Candidate> GetById(Guid id)
        {
            return await _unitOfWorkBootcamp.Candidate.GetById(id);
        }
        
    }
}
