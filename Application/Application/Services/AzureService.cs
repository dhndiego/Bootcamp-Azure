using Application.Services.Interfaces;
using Domain.Interfaces.Interfaces;
using Domain.Models;
using System.Text.Json;

namespace Application.Services
{
    public class AzureService : IAzureService
    {
        public AzureService(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        private readonly IServiceBus _serviceBus;
        public async Task<bool> Create(Candidate candidate)
        {
            try
            {
                await QueueCreateRegister(candidate);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private async Task QueueCreateRegister(Candidate candidate)
        {
            await _serviceBus.SendMessage("register", JsonSerializer.Serialize(candidate));
        }
    }
}
