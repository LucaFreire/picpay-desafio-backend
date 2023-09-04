using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Services;

public class TransactionsService : ITransactionsService
{
    public Task<bool> IsSufficientMoney(Transaction transaction)
    {
        throw new NotImplementedException();
    }
}