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
    [Route("api/[controller]")]
    public class WebhookRegistry : ControllerBase
    {

        [HttpPost("RegisterWebhook/{event}")]
        public async Task<IActionResult> RegisterWebhook(string @event)
        {
            string myEndpoint = "https://3b36-185-96-183-231.ngrok-free.app/api/WebhookRegistry/WebhookListener";
            string subscribeWebhook = $"https://my-project-webhook-dev.westeurope.azurecontainer.io:7443/api/Webhook/register/{@event}";

            try
            {
                // Bypass SSL certificate validation (not recommended for production environments)
                var httpClientHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };

                using var httpClient = new HttpClient(httpClientHandler);

                string endpointJson = JsonSerializer.Serialize(myEndpoint);
                StringContent jsonPackage = new StringContent(endpointJson, Encoding.UTF8, "application/json");

                await httpClient.PostAsync(subscribeWebhook, jsonPackage);

                return Ok();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }


        [HttpPost("UnregisterWebhook/{event}")]
        public async Task<IActionResult> UnregisterWebhook(string @event)
        {

            // needs to fit ngrok endpoint
            string myEndpoint = "https://3b36-185-96-183-231.ngrok-free.app/api/WebhookRegistry/WebhookListener";
            string unregisterWebhook = $"https://my-project-webhook-dev.westeurope.azurecontainer.io:7443/api/Webhook/unregister/{@event}";

            try
            {

                // Bypass SSL certificate validation (not recommended for production environments)
                var httpClientHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
                };

                HttpClient httpClient = new HttpClient(httpClientHandler);

                string endpointJson = JsonSerializer.Serialize(myEndpoint);

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
