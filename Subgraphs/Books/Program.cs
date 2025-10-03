var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<BookContext>();

builder.Services
    .AddGraphQLServer()
    .AddTypes();
var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
