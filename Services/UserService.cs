using Microsoft.EntityFrameworkCore;
using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Services;
public class UserService : IUserService
{
    readonly PicpayDesafioBackendContext context;
    public UserService(PicpayDesafioBackendContext ctx)
        => context = ctx;

    public async Task<User> GetUserById(int id)
    {
        try
        {
            var data = await context.Users.FirstOrDefaultAsync(user => user.UserId == id);
            return data;
        }
        catch (System.Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public async Task<bool> IsNewUser(string email, string document)
    {
        try
        {
            var isNewEmail = await context.Users.FirstOrDefaultAsync(user => user.Email == email);
            if (isNewEmail is not null)
                return false;

            var isNewDocument = await context.Users.FirstOrDefaultAsync(user => user.Document == document);
            if (isNewDocument is not null)
                return false;

            return true;
        }
        catch (System.Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public async Task<bool> IsSufficientMoney(Transaction transaction)
    {
        var payer = await GetUserById(transaction.Payer);

        if(payer.Balance >= transaction.TransactionValue)
            return true;
        return false;
    }
}