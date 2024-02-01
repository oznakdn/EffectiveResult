using ExampleApi.Dtos;
using ExampleApi.Services;
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
        return response.IsSuccessed ? Ok(new { message = response.Message, statusCode = response.StatusCode }) : BadRequest(response.Messages);
    }

    [HttpGet]
    public IActionResult GetUsers()
    {
        var response = userService.GetUsers();
        return response.IsSuccessed ? Ok(new {value = response.Values , statusCode= response.StatusCode}) : NotFound(new {message = response.Message, statusCode = response.StatusCode});
    }
}
