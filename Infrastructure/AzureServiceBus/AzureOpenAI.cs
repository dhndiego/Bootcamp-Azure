using Domain.Interfaces.Interfaces;
using Domain.Options;
using Microsoft.Extensions.Options;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using Infrastructure.Utils;
using Domain.Services;
using System.Text.Json;
using System.Text;

namespace Infrastructure.AzureServiceBus
{
    public class AzureOpenAI : IAzureOpenAI
    {
        public string _resourcename { get; set; }
        public string _deploymentId { get; set; }
        public string _apiKey { get; set; }
        public string _apiVersion { get; set; }

        public AzureOpenAI(IOptions<AzureOpenAIOptions> aiSettings)
        {
            _resourcename = aiSettings.Value.ResourceName;
            _deploymentId = aiSettings.Value.DeploymentId;
            _apiKey = aiSettings.Value.Key;
            _apiVersion = aiSettings.Value.ApiVersion;
        }

        public async Task<OpenAiResponse> AskToAI(string filePath, string question)
        {
            var dataText = PdfUtils.GetText(filePath);

            OpenAIAPI api = OpenAIAPI.ForAzure(_resourcename, _deploymentId, _apiKey);
            api.ApiVersion = _apiVersion;

            var result = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
            {
                Model = Model.DefaultChatModel,
                MaxTokens = 1000,
                Messages = new ChatMessage[] {
                    new ChatMessage(ChatMessageRole.System, "Você é um assistente de IA"),
                    new ChatMessage(ChatMessageRole.User, "A fonte da informação é o texto do PDF: " + dataText),
                    new ChatMessage(ChatMessageRole.User, question)
                }
            });

            if (result != null)
            {
                var jsonString = JsonSerializer.Serialize(result.Choices[0].Message);

                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
                {
                    var response = JsonSerializer.Deserialize<OpenAiResponse>(ms);

                    return response;
                }
            }
            else
            {
                return null;
            }

            
        }
    }
}
