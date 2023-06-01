using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL_Project_Impl.Subscriptions;
using GraphQL_Project_Impl.Types;
using HotChocolate.Subscriptions;

namespace GraphQL_Project_Impl.Mutations;

[ExtendObjectType("Mutation")]
public class UserMutation
{
    
    public async Task<User> CreateUser(
        string email, 
        string password, 
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
    {
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            Password = password
        };
        DataStore.users.Add(newUser);
        await eventSender.SendAsync(nameof(UserMutation.CreateUser), newUser, cancellationToken);
        return await Task.FromResult(newUser);
    }
}