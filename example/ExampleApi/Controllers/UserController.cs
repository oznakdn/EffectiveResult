using ExampleApi.Dtos;
using ExampleApi.Models;
using ExampleApi.Services;
using Gleeman.EffectiveResult.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExampleApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserDto user)
    {
        var response = userService.CreateUser(user);
        return response.IsSuccess ? Ok(response) : BadRequest(response.Messages);
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        IResponse<User> response = userService.GetUsers();

        return response.IsSuccess ? Ok(response) : NotFound(response);
    }
}
