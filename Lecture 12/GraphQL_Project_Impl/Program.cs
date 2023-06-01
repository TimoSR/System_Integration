using GraphQL_Project_Impl.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType(q => q.Name("Query"))
        .AddType<BookQuery>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
