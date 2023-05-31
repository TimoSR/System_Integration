using GraphQL_Schema_Example.Queries;
using GraphQL_Schema_Example.Schema;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddGraphQLServer()
    .AddDocumentFromFile("./Schema.graphql")
    .BindRuntimeType<Book>()
    .BindRuntimeType<Query>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
