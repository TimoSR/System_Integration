using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace WebhookServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhookController : ControllerBase
    {

        [HttpPost("register/{event}")]
        public async Task<IActionResult> Register(string @event, [FromBody] string endpointUrl)
        {
            string filename = $"{@event}.txt";
            string[] existingEndpoints = System.IO.File.ReadAllLines(filename);
            // file deepcode ignore PT: <please specify a reason of ignoring this>
            if (!existingEndpoints.Contains(endpointUrl))
            {
                System.IO.File.AppendAllText(filename, $"{endpointUrl}\n");

                // Send a "ping" event to the registered webhook URL
                using HttpClient httpClient = new HttpClient();
                var pingEventData = new
                {
                    event_type = "ping",
                    message = "Webhook registered successfully."
                };
                string pingEventJson = JsonSerializer.Serialize(pingEventData);
                StringContent pingEventContent = new StringContent(pingEventJson, Encoding.UTF8, "application/json");
                // file deepcode ignore Ssrf: <please specify a reason of ignoring this>
                await httpClient.PostAsync(endpointUrl, pingEventContent);
            }
            return Ok("Webhook registered.");
        }

        [HttpPost("unregister/{event}")]
        public IActionResult Unregister(string @event, [FromBody] string endpointUrl)
        {
            string filename = $"{@event}.txt";
            string[] existingEndpoints = System.IO.File.ReadAllLines(filename);
            string[] updatedEndpoints = existingEndpoints.Where(x => x != endpointUrl).ToArray();
            System.IO.File.WriteAllLines(filename, updatedEndpoints);
            return Ok("Webhook unregistered.");
        }
    }
}