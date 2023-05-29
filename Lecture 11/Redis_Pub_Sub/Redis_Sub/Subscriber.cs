using StackExchange.Redis;

DotNetEnv.Env.Load();
var redisConnectionString = Environment.GetEnvironmentVariable("REDIS_CONNECTION_STRING");

// Create a connection to Redis server
var redis = ConnectionMultiplexer.Connect(redisConnectionString);

var pubSub = redis.GetSubscriber();

pubSub.Subscribe("myChannel", (channel, message) =>
{
    // Print each message
    Console.WriteLine(message);

    // If the message is "quit", unsubscribe
    if (message == "quit")
    {
        pubSub.Unsubscribe("myChannel");
    }
});

// Wait for a key press to end the program
Console.ReadKey();