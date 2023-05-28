using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace File_Server.Controllers;

[ApiController]
[Route("[controller]")]
public class UploadController : ControllerBase
{
    
    private readonly ILogger<UploadController> _logger;
    
    public UploadController(ILogger<UploadController> logger)
    {
        _logger = logger;
    }
    
    [HttpPost("form")]
    public IActionResult FormHandler(string username, string password)
    {
        _logger.Log(LogLevel.Information, $"User {username} is created");
        return Ok();
    }
}