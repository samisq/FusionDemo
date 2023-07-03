var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services
    .AddFusionGatewayServer()
    .ConfigureFromFile("./gateway.fgp",
        watchFileForUpdates: true);

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
