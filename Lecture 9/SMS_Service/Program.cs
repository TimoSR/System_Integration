// Load environment variables from .env file (if you're using DotNetEnv)
DotNetEnv.Env.Load();

// Access the environment variables
string servicePlanId = Environment.GetEnvironmentVariable("YOUR_servicePlanId");
string apiToken = Environment.GetEnvironmentVariable("YOUR_API_token");
string sinchVirtualNumber = Environment.GetEnvironmentVariable("YOUR_Sinch_virtual_number");
string recipient_number = Environment.GetEnvironmentVariable("YOUR_Recipient_Number");

SMS sms = new SMS(sinchVirtualNumber, new string[] {recipient_number}, "Tim's SMS Service says HI!" );
sms.sendSMS(sms, servicePlanId, apiToken);
Console.ReadLine();