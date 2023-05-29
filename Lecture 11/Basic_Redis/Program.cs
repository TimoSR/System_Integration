using Redis.OM;
using StackExchange.Redis;

DotNetEnv.Env.Load();
var redisConnectionString = Environment.GetEnvironmentVariable("REDIS_CONNECTION_STRING");

// Create a connection to Redis server
ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConnectionString);

// Get a database from the connection (db 0 is default)
IDatabase db = redis.GetDatabase();

// Get a different database from the connection (for example, db 1)
//IDatabase db = redis.GetDatabase(1);

// Set a value
db.StringSet("myKey2", "my value 2");

// Get the value
string value = db.StringGet("myKey2");

// To set a value with an expiration (uncomment below if needed)
db.StringSet("myKey", "my value", TimeSpan.FromSeconds(10));

// Output the value
Console.WriteLine(value);