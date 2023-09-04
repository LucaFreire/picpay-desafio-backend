using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Services;

public interface IUserService
{
    Task<User> GetUserById(int id);
}