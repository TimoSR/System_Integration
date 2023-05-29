using Redis.OM;
using Basic_Redis.Customer;
using StackExchange.Redis;

DotNetEnv.Env.Load();
var redisConnectionString = Environment.GetEnvironmentVariable("REDIS_CONNECTION_STRING");

// Create a connection to Redis server
ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConnectionString);

// Get a database from the connection (db 0 is default)
IDatabase db = redis.GetDatabase();

// Set a value
db.StringSet("myKey", "my value");

// Get the value
string value = db.StringGet("myKey");

// To set a value with an expiration (uncomment below if needed)
// db.StringSet("myKey", "my value", TimeSpan.FromSeconds(10));

// Output the value
Console.WriteLine(value);
