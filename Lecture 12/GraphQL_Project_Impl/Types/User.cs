namespace GraphQL_Project_Impl.Types;

public class User
{
    //Private
    private string _password;
    
    //Public 
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { set => _password = value; }
} 