namespace GraphQL_Project_Impl.Types;

public class InsertResult
{
    public List<string> Errors { get; set; }
    public Guid Id { get; set; }
}