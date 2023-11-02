using System.Net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using picpay_desafio_backend.Model;
using picpay_desafio_backend.Respositories;
using picpay_desafio_backend.Services;

namespace picpay_desafio_backend.Controllers;

[ApiController]
[Route("transactions")]
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

    [HttpPost("Register")]
    public async Task<ActionResult> Register(
        [FromServices] IRepository<User> userRepository,
        [FromServices] IUserService userService,
        [FromBody] UserDTO userDTO)
    {
        try
        {
            bool isNewUser = await userService.IsNewUser(userDTO.Email, userDTO.Document);

            if (!isNewUser)
                return BadRequest("Document or Email is already in use!");

            User newUser = new(userDTO);
            bool created = await userRepository.Create(newUser);

            if (!created)
                return BadRequest();

            return Ok();
        }
        catch (Exception error)
        {
            return StatusCode(500, error.Message);
        }
    }

}