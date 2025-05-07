using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] string query)
        {
            var projects = _projectService.GetAll(query);
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);
            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpPost]
        public IActionResult Create([FromBody] NewProductInputModel inputModel)
        {
            var id = _projectService.Create(inputModel);
            return CreatedAtAction(nameof(GetById), new { id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateProductInputModel inputModel)
        {
            if (id != inputModel.Id)
                return BadRequest();

            _projectService.Update(inputModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _projectService.Delete(id);
            return NoContent();
        }

        [HttpPost("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);
            return NoContent();
        }

        [HttpPost("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);
            return NoContent();
        }

        [HttpPost("comments")]
        public IActionResult CreateComment([FromBody] CreateCommentInputModel inputModel)
        {
            _projectService.CreateComment(inputModel);
            return NoContent();
        }
    }
}