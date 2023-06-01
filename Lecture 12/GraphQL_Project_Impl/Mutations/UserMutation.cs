using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL_Project_Impl.Types;

namespace GraphQL_Project_Impl.Mutations;

[ExtendObjectType("Mutation")]
public class UserMutation
{
    // User methods
    public async Task<User> CreateUser(string email, string password)
    {
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            Password = password
        };
        DataStore.users.Add(newUser);
        
        return await Task.FromResult(newUser);
    }
}