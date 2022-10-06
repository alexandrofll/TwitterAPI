using TwitterAPI.Application.Options;
using TwitterAPI.DataPullingService;
using TwitterAPI.DataPullingService.Services;
using TwitterAPI.TwiterCore.Client;
using TwitterAPI.TwiterCore.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        //extract values from the IConfiguration
        //instance into your custom type 
        services.AddOptions<TwitterAPISettings>()
        .Configure<IConfiguration>((settings, configuration) =>
        {
            configuration.GetSection("TwitterAPISettings").Bind(settings);
        });

        services.AddHostedService<Worker>();
        services.AddSingleton<ISampleStreamService, SampleStreamService>();
        services.AddHttpClient<ISampleStreamClient, SampleStreamClient>(client =>
        {
            client.BaseAddress = new Uri("https://api.twitter.com");
        });
        //TODO: SETUP POLLY
        //.AddPolicyHandler(GetRetryPolicy())
        //.AddPolicyHandler(GetCircuitBreakerPolicy());
        services.AddHttpClient<IDataService, DataService>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:44313/");
        });
        //TODO: SETUP POLLY
        //.AddPolicyHandler(GetRetryPolicy())
        //.AddPolicyHandler(GetCircuitBreakerPolicy());

    })
    .Build();

await host.RunAsync();


