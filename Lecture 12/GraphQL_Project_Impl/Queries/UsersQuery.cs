using GraphQL_Project_Impl.Types;

namespace GraphQL_Project_Impl.Queries;

[ExtendObjectType("Query")]
public class UsersQuery
{
    public List<User> GetAllUsers()
    {
        var listOfUsers = DataStore.users;

        return listOfUsers;
    }
}