using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

using picpay_desafio_backend.Model;
using picpay_desafio_backend.Services;
using picpay_desafio_backend.Repositories;

namespace picpay_desafio_backend.Controllers;

[ApiController]
[Route("transactions")]
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

    [HttpPost("transaction")]
    public async Task<ActionResult> Transfer(
        [FromBody] TransactionDTO transactionDTO,
        [FromServices] ITransactionService transactionService,
        [FromServices] IUserService userService,
        [FromServices] IAuthorizeService authorizeService,
        [FromServices] IRepository<User> userRepository,
        [FromServices] IRepository<Transaction> transactionRepository)
    {
        try
        {
            bool isPaymentAuthorized = await authorizeService.Authorized();
            if (!isPaymentAuthorized)
                return StatusCode(401, "Transfer not authorized.");

            (User payer, User payee) = await userService.IsTransactionUsersValid(transactionDTO);

            bool isValidPlayer = transactionService.IsValidPayer(payer);
            if (!isValidPlayer)
                return StatusCode(401, "Transfer not authorized, make sure that your user's type is valid.");

            bool isEnoughMoneyToPayment = userService.IsSufficientMoney(payer, transactionDTO);
            if (!isEnoughMoneyToPayment)
                return StatusCode(401, "Not enough money to transfer.");

            payer.RemoveMoney(transactionDTO.value);
            payee.AddMoney(transactionDTO.value);
            Transaction transaction = new(transactionDTO);

            userRepository.UpdateNoSave(payer);
            userRepository.UpdateNoSave(payee);
            await transactionRepository.Create(transaction);

            return Ok(transaction);
        }
        catch (Exception error)
        {
            return StatusCode(500, error.Message);
        }
    }
}
