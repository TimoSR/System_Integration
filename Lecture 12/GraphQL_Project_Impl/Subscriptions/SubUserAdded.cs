using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL_Project_Impl.Mutations;
using GraphQL_Project_Impl.Types;
using HotChocolate.Subscriptions;

namespace GraphQL_Project_Impl.Subscriptions;

[ExtendObjectType("Subscription")]
public class UserSubscription
{
    [Subscribe]
    public async Task<User> OnUserCreated([EventMessage] User newUser)
    {
        return newUser;
    }
}