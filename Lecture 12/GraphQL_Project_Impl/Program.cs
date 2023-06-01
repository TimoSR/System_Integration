using GraphQL_Project_Impl;
using GraphQL_Project_Impl.Mutations;
using GraphQL_Project_Impl.Queries;
using GraphQL_Project_Impl.Subscriptions;
using GraphQL_Project_Impl.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType(q => q.Name("Query"))
        .AddType<BookQuery>()
        .AddType<BlogsQuery>()
        .AddType<BlogQuery>()
        .AddType<UsersQuery>()
    .AddMutationType(m => m.Name("Mutation"))
        .AddType<BlogMutation>()
        .AddType<UserMutation>()
        .AddType<BookMutation>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions();

var app = builder.Build();

app.UseWebSockets();
app.MapGraphQL();

app.Run();
