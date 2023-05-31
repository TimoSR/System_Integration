using GraphQL_Annotation_Example.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType(q => q.Name("Query"))
        .AddType<AnnotationQuery>()
        .AddType<BookQuery>();

var app = builder.Build();

app.MapGraphQL();

app.Run();