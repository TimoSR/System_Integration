using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_api.application;
using dotnet_api.domain;
using Newtonsoft.Json.Linq;

namespace dotnet_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet("getJson")]
        public ActionResult<Person> GetJson()
        {

            PersonFilesParser parser = new PersonFilesParser();

            return parser.jsonContents;

        }
    }
}