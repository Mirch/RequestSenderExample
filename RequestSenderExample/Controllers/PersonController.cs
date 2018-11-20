using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RequestSenderExample.Models;
using SWriter.RequestManager;

namespace RequestSenderExample.Controllers
{

    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        [HttpGet("getPerson")]
        public IActionResult GetPerson()
        {
            return Ok(new Person() { Name = "John", Age = 23});
        }

        [HttpPost("postPerson")]
        public IActionResult GetStringPost([FromBody]Person person)
        {
            return Ok(person);
        }

    }
}
