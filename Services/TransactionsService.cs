using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Services;

public class TransactionsService : ITransactionsService
{
    public bool IsSufficientMoney(User user, decimal? transactionValue)
    {
        if (user.Balance >= transactionValue)
            return true;
        return false;
    }
}
