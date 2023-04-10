using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebhookIntegrator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebhookRegistry : ControllerBase
    {

        [HttpPost("RegisterWebhook/{event}")]
        public async Task<IActionResult> RegisterWebhook(string @event, [FromBody] string myEndpoint)
        {

            string subscribeWebhook = $"https://localhost:7443/api/Webhook/register/{@event}";

            try
            {

                HttpClient httpClient = new HttpClient();

                string endpointJson = JsonSerializer.Serialize(myEndpoint);
                StringContent jsonPackage = new StringContent(endpointJson, Encoding.UTF8, "application/json");

                await httpClient.PostAsync(subscribeWebhook, jsonPackage);


                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPost("UnregisterWebhook/{event}")]
        public async Task<IActionResult> UnregisterWebhook(string @event, [FromBody] string myEndpoint)
        {

            string unregisterWebhook = $"https://localhost:7443/api/Webhook/unregister/{@event}";

            try
            {

                HttpClient httpClient = new HttpClient();

                string endpointJson = JsonSerializer.Serialize(registeredEndpoint);

                StringContent jsonPackage = new StringContent(endpointJson, Encoding.UTF8, "application/json");

                await httpClient.PostAsync(unregisterWebhook, jsonPackage);

                return Ok();


            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
        }

        [HttpPost("WebhookListener")]
        public async Task<IActionResult> WebhookListener()
        {

            try
            {
                Console.WriteLine("Notification: Received something!");

                //Reading the request body Async

                var reader = new StreamReader(Request.Body);
                var content = await reader.ReadToEndAsync();
                var jsonString = JsonSerializer.Deserialize<JsonElement>(content);

                Console.WriteLine(jsonString);

                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }

        }
    }
}
