namespace GraphQL_Project_Impl.Types;

public record Blog(
    Guid Id, 
    string Title, 
    string Description,
    bool Completed,
    Guid OwnerId);