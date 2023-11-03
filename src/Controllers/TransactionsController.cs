using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using picpay_desafio_backend.Model;
using picpay_desafio_backend.Repositories;

namespace picpay_desafio_backend.Controllers;

[ApiController]
[Route("transaction")]
[EnableCors("MainPolicy")]
public class TransactionsController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<Transaction>>> Get(
        [FromServices] IRepository<Transaction> transactionRepository)
    {
        try
        {
            var data = await transactionRepository.Filter(_ => true);

            if (data is null)
                return BadRequest();

            return Ok(data);
        }
        catch (Exception error)
        {
            return StatusCode(500, error.Message);
        }
    }
}
