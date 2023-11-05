using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using picpay_desafio_backend.Model;
using picpay_desafio_backend.Repositories;
using picpay_desafio_backend.Services;

namespace picpay_desafio_backend.Controllers;

[ApiController]
[Route("user")]
[EnableCors("MainPolicy")]
public class UserController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<User>>> Get(
        [FromServices] IRepository<User> userRepository)
    {
        try
        {
            var data = await userRepository.Filter(_ => true);

            if (data is null)
                return BadRequest();

            return Ok(data);
        }
        catch (Exception error)
        {
            return StatusCode(500, error.Message);
        }
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register(
        [FromBody] UserDTO userDTO,
        [FromServices] IRepository<User> userRepository,
        [FromServices] IUserService userService)
    {
        try
        {
            var isNewUser = await userService.IsNewUser(userDTO.Email, userDTO.Document);

            User newUser = new(userDTO);

            bool created = await userRepository.Create(newUser);

            if (!created)
                return BadRequest();

            return Ok(newUser);
        }
        catch (Exception error)
        {
            return StatusCode(500, error.Message);
        }
    }
}