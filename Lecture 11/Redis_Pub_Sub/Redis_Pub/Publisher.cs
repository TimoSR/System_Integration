using StackExchange.Redis;

DotNetEnv.Env.Load();
var redisConnectionString = Environment.GetEnvironmentVariable("REDIS_CONNECTION_STRING");

// Create a connection to Redis server
var redis = ConnectionMultiplexer.Connect(redisConnectionString);

var pubSub = redis.GetSubscriber();

pubSub.Publish("myChannel", "Hello, World!");