using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using picpay_desafio_backend.DTO;
using picpay_desafio_backend.Model;
using picpay_desafio_backend.Respositories;
using picpay_desafio_backend.Services;

namespace picpay_desafio_backend.Controllers;

[ApiController]
[Route("transactions")]
[EnableCors("MainPolicy")]
public class TransactionsController : ControllerBase
{
    [HttpPost("add")]
    public async Task<ActionResult> CreateTransaction(
        [FromServices] TransactionsRespository transactionsRespository,
        [FromServices] IUserService userService,
        [FromServices] ITransactionsService transactionsService,
        [FromServices] ITypeUserService typeUserService,
        [FromBody] TransactionDTO transactionDTO
        )
    {

        Transaction transaction = new()
        {
            TransactionValue = transactionDTO.Value,
            Payee = transactionDTO.PayeeId,
            Payer = transactionDTO.PayerId
        };

        var payerEntity = await userService.GetUserById(transactionDTO.PayerId);

        bool isEnoughMoney = transactionsService.IsSufficientMoney(payerEntity, transaction.TransactionValue);

        if (!isEnoughMoney)
            return BadRequest();

        string userType = typeUserService.GetUserType(payerEntity.UserType);
        bool isAuthorizedUser = typeUserService.IsUserAuthorizedToTransfer(payerEntity.UserType);

        var payeeEntity = await userService.GetUserById(transactionDTO.PayeeId);

        payeeEntity.Balance += transaction.TransactionValue;
        payerEntity.Balance -= transaction.TransactionValue;


        bool created = await transactionsRespository.Create(transaction);

        if (!created)
            return StatusCode(500);
    }
}
