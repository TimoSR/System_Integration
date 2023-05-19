using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using FileHandlerLib.application;
using FileHandlerLib.domain;

namespace dotnet_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        static FileReader reader = new FileReader();
        static JsonSerializer serializer = new JsonSerializer();

        [HttpGet("getJson")]
        public ActionResult GetJson()
        {

            var jsonContent = reader.readJsonFile();            

            return Content(jsonContent, "application/json");

        }

        [HttpGet("getText")]
        public ActionResult GetText() {

            var textContent = reader.readTextFile();

            return Content(textContent, "text/plain");
            
        }

        [HttpGet("getYamlAsJSON")]
        public ActionResult GetYamlJson() {
            var yamlContent = serializer.YamlToJson();
            return Content(yamlContent, "application/json");
        }
    }
}