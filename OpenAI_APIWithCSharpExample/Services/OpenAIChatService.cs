using Microsoft.Extensions.Hosting;
using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels.ResponseModels;

namespace OpenAI_APIWithCSharpExample.Services;

public class OpenAIChatService : BackgroundService
{
    private readonly IOpenAIService _openAIService;

    public OpenAIChatService(IOpenAIService openAiService)
    {
        _openAIService = openAiService;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine($"Ben son derece zeki bir soru yanıtlama robotuyum. Bana hakikate dayanan bir soru sorarsan, sana cevabını veririm. Bana saçma, hileli veya net bir cevabı olmayan bir soru sorarsanız, 'Bilinmeyen' ifadesi cevap vereceğim.");
        while (true)
        {
            Console.Write("::");
            CompletionCreateResponse result = await _openAIService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = Console.ReadLine(),
                MaxTokens = 500,
                Temperature = 0,
                TopP = 1,
                FrequencyPenalty = 0,
                PresencePenalty = 0,
                Stop = "."
            }, Models.TextDavinciV3);

            Console.WriteLine(result.Choices[0].Text);
        }
    }
}