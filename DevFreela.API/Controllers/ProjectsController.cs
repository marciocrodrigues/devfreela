using System;
using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
	[Route("api/projects")]
	public class ProjectsController : ControllerBase
	{
		private readonly IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
			_projectService = projectService;
        }

		[HttpGet]
		public IActionResult Get(string query)
        {
			return Ok(_projectService.GetAll(query));
        }

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
        {
			return Ok(_projectService.GetById(id));
        }

		[HttpPost]
		public IActionResult Post([FromBody] NewProjectInputModel createProject)
        {
			var id = _projectService.Create(createProject);

			if (!string.IsNullOrEmpty(id.ToString()))
            {
				return BadRequest();
            }

			return CreatedAtAction(nameof(GetById), new { id = id }, createProject);
        }

		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] UpdateProjectInputModel updateProject)
        {
			updateProject.Id = id;

			_projectService.Update(updateProject);

			if (updateProject.Description.Length > 200)
            {
				return BadRequest();
            }

			return NoContent();
        }

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
        {

			_projectService.Delete(id);

			return NoContent();
        }

		[HttpPost("id/comments")]
		public IActionResult PostComment(int id, [FromBody]CreateCommentInputModel commentModel)
        {
			commentModel.IdProject = id;
			_projectService.CreateComment(commentModel);

            return NoContent();
        }

		[HttpPut("{id}/start")]
		public IActionResult Start(int id)
        {
			_projectService.Start(id);

			return NoContent();
        }

		[HttpPut("{id}/finish")]
		public IActionResult Finish(int id)
        {
			_projectService.Finish(id);
			return NoContent();
        }
	}
}

