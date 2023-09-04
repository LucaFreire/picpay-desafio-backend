using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Services;

public interface ITransactionsService
{
    Task<bool> IsSufficientMoney(Transaction transaction);
}