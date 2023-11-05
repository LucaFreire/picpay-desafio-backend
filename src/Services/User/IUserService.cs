using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Services;

public interface IUserService
{
    Task<User> GetUserById(int id);
    Task<(User payer, User payee)> IsTransactionUsersValid(TransactionDTO transactionDTO);
    Task<bool> IsNewUser(string email, string document);
    bool IsSufficientMoney(User payer, TransactionDTO transactionDTO);
}