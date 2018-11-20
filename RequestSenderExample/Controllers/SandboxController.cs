using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestSenderExample.Models;
using SWriter.RequestManager;

namespace RequestSenderExample.Controllers
{
    [Route("api/[controller]")]
    public class SandboxController : Controller
    {
        private RequestSender _requestSender;

        public SandboxController()
        {
            _requestSender = new RequestSender("https://localhost:44327/api/person/");
        }

        [HttpGet("get")]
        public async Task<IActionResult> TestGetMethod()
        {
            var result = (await _requestSender.GetAsync("getPerson")).ResultAs<Person>(ContentType.JSON);

            return Ok(result);
        }

        [HttpGet("post")]
        public async Task<IActionResult> TestPostMethod()
        {
            var person = new Person() { Name = "Jimmy", Age = 103 };

            var result = (await _requestSender.PostAsync("postPerson", person, ContentType.XML)).ResultAs<Person>(ContentType.XML);

            return Ok(result);
        }

    }
}