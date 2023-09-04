using Microsoft.EntityFrameworkCore;
using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Services;
public class UserService : IUserService
{
    private PicpayDesafioBackendContext context;
    public UserService(PicpayDesafioBackendContext ctx)
        => this.context = ctx;

    public async Task<User> GetUserById(int id)
    {
        try
        {
            var data = await context.Users.FirstOrDefaultAsync(user => user.UserId == id);
            return data;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}