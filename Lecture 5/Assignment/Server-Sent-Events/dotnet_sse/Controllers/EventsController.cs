using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace dotnet_sse.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        [HttpGet]
        public async Task Get(CancellationToken cancellationToken){
            
            Response.Headers.Add("Content-Type", "text/event-stream");
            Response.Headers.Add("Cache-Control", "no-cache");
            Response.Headers.Add("Connection", "keep-alive");

            await Response.Body.FlushAsync();

            var iterator = 0;

            while (iterator < 10 || cancellationToken.IsCancellationRequested)
            {

                var time = DateTime.Now.ToString("HH:mm:ss");
                var data = $"data: {time}\n\n";

                await Response.WriteAsync(data);
                await Response.Body.FlushAsync();

                await Task.Delay(1000);

                iterator += 1;
            }
            
        }
    }
}