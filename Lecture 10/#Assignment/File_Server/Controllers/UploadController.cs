using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace File_Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UploadController : ControllerBase
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<UploadController> _logger;
    
    
    public UploadController(ILogger<UploadController> logger, IWebHostEnvironment environment)
    {
        _logger = logger;
        _environment = environment;
    }
    
    // Basic Form Example
    [HttpPost("Form")]
    public IActionResult FormHandler(string username, string password)
    {
        _logger.Log(LogLevel.Information, $"User {username} is created");
        _logger.Log(LogLevel.Information, $"Environment: {_environment.EnvironmentName}");
        _logger.Log(LogLevel.Information, $"Contentroot path: {_environment.ContentRootPath}");
        _logger.Log(LogLevel.Information, $"Webroot path: {_environment.WebRootPath}");

        return Ok();
    }

    [HttpPost("AnyFile")]
    public IActionResult AnyFile(IFormFile file)
    {

        // Validate file size
        const long maxFileSize = 20 * 1024 * 1024; // 20 MB
        if (file.Length > maxFileSize)
        {
            return BadRequest("File size exceeds the limit (20 MB)");
        }

        FileWriter(file);
    
        return Ok("File uploaded successfully");
    }

    [HttpPost("Image")]
    public IActionResult Image(IFormFile file)
    {
        // Validate file type
        var allowedMimeTypes = new[] { "image/jpeg", "image/png", "image/gif" };
        if (!allowedMimeTypes.Contains(file.ContentType))
        {
            return BadRequest("Invalid file type");
        }

        // Validate file size
        const long maxFileSize = 20 * 1024 * 1024; // 20 MB
        if (file.Length > maxFileSize)
        {
            return BadRequest("File size exceeds the limit (20 MB)");
        }

        FileWriter(file);
    
        return Ok("File uploaded successfully");
    }

    [HttpPost("Gif")]
    public IActionResult Gif(IFormFile file)
    {
        // Validate file type
        var allowedMimeTypes = new[] { "image/gif" };
        if (!allowedMimeTypes.Contains(file.ContentType))
        {
            return BadRequest("Invalid file type");
        }

        // Validate file size
        const long maxFileSize = 20 * 1024 * 1024; // 20 MB
        if (file.Length > maxFileSize)
        {
            return BadRequest("File size exceeds the limit (20 MB)");
        }

        FileWriter(file);
    
        return Ok("File uploaded successfully");
    }

    private void FileWriter(IFormFile file) {
        var webRootPath = _environment.WebRootPath;
        var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
        Directory.CreateDirectory(uploadsFolder);
        var filePath = Path.Combine(uploadsFolder, file.FileName);
        using var fileStream = new FileStream(filePath, FileMode.Create);
        file.CopyTo(fileStream);
    }

}