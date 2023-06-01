using GraphQL_Project_Impl;
using GraphQL_Project_Impl.Mutations;
using GraphQL_Project_Impl.Queries;
using GraphQL_Project_Impl.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType(q => q.Name("Query"))
        .AddType<BookQuery>()
        .AddType<BlogsQuery>()
        .AddType<BlogQuery>()
    .AddMutationType(m => m.Name("Mutation"))
        .AddType<BlogMutation>()
        .AddType<UserMutation>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
