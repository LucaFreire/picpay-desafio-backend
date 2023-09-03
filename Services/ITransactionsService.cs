
namespace picpay_desafio_backend.Services;

public interface ITransactionsService
{
    Task<bool> Transfer();
    Task<bool> IsSufficientMoney();

}