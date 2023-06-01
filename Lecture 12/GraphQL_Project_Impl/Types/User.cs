namespace GraphQL_Project_Impl.Types;

public class User
{
    //Public
    public Guid Id { get; set; }
    public string Email { get; set; }
    [GraphQLIgnore]
    public string Password { get; set; }
} 