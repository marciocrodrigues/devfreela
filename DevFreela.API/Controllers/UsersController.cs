using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            return Ok(_userService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewUserInputModel createUserModel)
        {
            var id = _userService.Create(createUserModel);

            if (!string.IsNullOrEmpty(id.ToString()))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new { id = id }, createUserModel);
        }

        [HttpPost("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel loginModel)
        {
            return NoContent();
        }
    }
}

