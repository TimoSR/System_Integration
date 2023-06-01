
using GraphQL_Project_Impl.Types;
using HotChocolate.Subscriptions;

namespace GraphQL_Project_Impl.Mutations;

[ExtendObjectType("Mutation")]
public class UserMutation
{ 
    public async Task<User> CreateUser(string email, string password)
    {
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            Password = password
        };
        
        DataStore.users.Add(newUser);
        return await Task.FromResult(newUser);;
    }
    
}