using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Interfaces
{
    public interface IAzureOpenAI
    {
        Task<OpenAiResponse> AskToAI(string filePath, string question);
    }
}
