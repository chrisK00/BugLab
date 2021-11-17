using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BugLab.API.Controllers
{
    // TODO: remove when exc handling on front-end is set up
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {
        [HttpGet("not-found")]
        public IActionResult NotFoundResponse()
        {
            throw new KeyNotFoundException();
        }

        [HttpGet("bad-request")]
        public IActionResult BadRequestResponse()
        {
            throw new InvalidOperationException();
        }
    }
}
