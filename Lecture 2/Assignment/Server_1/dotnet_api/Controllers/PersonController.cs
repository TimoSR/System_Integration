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
        [HttpGet("getJson")]
        public ActionResult<Person> GetJson()
        {

            FileReader reader = new FileReader();
            var jsonContent = reader.readJsonFile();
            

            return Content(jsonContent, "application/json");

        }
    }
}