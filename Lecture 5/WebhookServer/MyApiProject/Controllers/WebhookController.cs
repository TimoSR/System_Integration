using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhookController : ControllerBase
    {
        [HttpPost("register/{event}")]
        public IActionResult Register(string e_event, [FromBody] string endpointUrl)
        {
            System.IO.File.AppendAllText($"{e_event}.txt", endpointUrl + "\n");
            return Ok("Webhook registered.");
        }

        [HttpPost("unregister/{event}")]
        public IActionResult Unregister(string e_event, [FromBody] string endpointUrl)
        {
            // file deepcode ignore PT: <please specify a reason of ignoring this>
            string[] endpoints = System.IO.File.ReadAllLines($"{e_event}.txt");
            string[] updatedEndpoints = endpoints.Where(x => x != endpointUrl).ToArray();
            System.IO.File.WriteAllLines($"{e_event}.txt", updatedEndpoints);
            return Ok("Webhook unregistered.");
        }
    }
}