var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<BookContext>();

builder.Services
    .AddGraphQLServer()
    .AddTypes()
    .RegisterService<BookContext>();

var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
