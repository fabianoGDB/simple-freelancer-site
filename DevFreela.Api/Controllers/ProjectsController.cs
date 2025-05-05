using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(id);
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Hello World");
        }
    }
}