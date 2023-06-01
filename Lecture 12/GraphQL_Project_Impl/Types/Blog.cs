namespace GraphQL_Project_Impl.Types;

public record Blog
{
    public Guid Id { get; set; } 
    public string Title { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public Guid OwnerId { get; set; }
}