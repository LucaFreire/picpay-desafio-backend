using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace picpay_desafio_backend.Controllers;

[ApiController]
[Route("transactions")]
[EnableCors("MainPolicy")]
public class TransactionsController : ControllerBase
{
    
}
