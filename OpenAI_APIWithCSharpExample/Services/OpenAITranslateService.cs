using Microsoft.Extensions.Hosting;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;

namespace OpenAI_APIWithCSharpExample.Services
{
    public class OpenAITranslateService : BackgroundService
    {
        private readonly IOpenAIService _openAIService;

        public OpenAITranslateService(IOpenAIService openAiService)
        {
            _openAIService = openAiService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                Console.Write("::");
                CompletionCreateResponse result = await _openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
                {
                    Prompt = Console.ReadLine(),
                    MaxTokens = 500,
                    Temperature = (float?)(0.3),
                    TopP = 1,
                    FrequencyPenalty = 0,
                    PresencePenalty = 0
                }, Models.TextDavinciV3);

                Console.WriteLine(result.Choices[0].Text);
            }
        }
    }
}
