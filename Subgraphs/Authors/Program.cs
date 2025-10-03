var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<AuthorContext>();

builder.Services
    .AddGraphQLServer()
    .AddAuthorTypes();

var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
