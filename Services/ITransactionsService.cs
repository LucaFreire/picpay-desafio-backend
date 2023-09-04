using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Services;

public interface ITransactionsService
{
    bool IsSufficientMoney(User user, decimal? transactionValue);
}
