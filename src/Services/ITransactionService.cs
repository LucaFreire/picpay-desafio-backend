using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Services;

public interface ITransactionService
{
    bool IsValidPayer(User payer);
}