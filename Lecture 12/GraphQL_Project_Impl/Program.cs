using GraphQL_Project_Impl.Mutations;
using GraphQL_Project_Impl.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType(q => q.Name("Query"))
        .AddType<BookQuery>()
    .AddMutationType(m => m.Name("Mutation"))
        .AddType<CreateBlog>()
        .AddType<CreateUser>()
        .AddType<CreateToken>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
