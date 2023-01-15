using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenAI.GPT3.Extensions;
using OpenAI_APIWithCSharpExample.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {

        services.AddOpenAIService(settings => settings.ApiKey = "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");
        //services.AddHostedService<OpenAITranslateService>();
        services.AddHostedService<OpenAIChatService>();

    })
    .Build();

host.Run();