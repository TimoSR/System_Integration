using GraphQL_Project_Impl.Types;
using HotChocolate.Subscriptions;

namespace GraphQL_Project_Impl.Mutations;

[ExtendObjectType("Mutation")]
public class BookMutation
{
    public async Task<Book> AddBook(string title, string author, [Service] ITopicEventSender sender)
    {

        var book = new Book
            {
                Title = title,
                Author = author
            };

        // Publish the event
        await sender.SendAsync("BookAdded", book);
        return await Task.FromResult(book);
    }
}