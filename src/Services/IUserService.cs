using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Services;

public interface IUserService
{
    Task<User> GetUserById(int id);
    Task<bool> IsNewUser(string email, string document);
    Task<bool> IsSufficientMoney(Transaction transaction);
}