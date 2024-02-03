using ExampleApi.Dtos;
using ExampleApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateRole([FromBody] RoleDto roleDto)
    {
        var role = new Role(roleDto.Title);
        var response = Role.CreateRole(role);
        return response.IsSuccess ? Ok(response) : BadRequest(response);
    }

    [HttpGet]
    public IActionResult GetRoles()
    {
        var response = Role.GetRoles();
        return response.IsSuccess ? Ok(response) : NotFound(response);
    }
}
