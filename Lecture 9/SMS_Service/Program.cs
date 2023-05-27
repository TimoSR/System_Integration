
// Load environment variables from .env file (if you're using DotNetEnv)
DotNetEnv.Env.Load();

// Access the environment variables
string servicePlanId = Environment.GetEnvironmentVariable("YOUR_servicePlanId");
string apiToken = Environment.GetEnvironmentVariable("YOUR_API_token");
string sinchVirtualNumber = Environment.GetEnvironmentVariable("YOUR_Sinch_virtual_number");
string recipient_number = "+45205555";

SMS sms = new SMS(sinchVirtualNumber, new string[] {recipient_number}, "Hello from Sinch!" );
sms.sendSMS(sms, servicePlanId, apiToken);
Console.ReadLine();