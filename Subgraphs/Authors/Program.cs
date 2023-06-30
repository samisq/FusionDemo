var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSingleton<AuthorContext>();

builder.Services
    .AddGraphQLServer()
    .AddAuthorTypes()
    .RegisterService<AuthorContext>();

var app = builder.Build();

app.UseWebSockets();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
