using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Services;

public class TransactionService : ITransactionService
{

    public bool IsValidPayer(User payer)
    {
        var userType = payer.UserType;

        return userType switch
        {
            UserType.COMMON => true,
            UserType.MERCHANDISE => false,
            _ => throw new Exception("Invalid UserType")
        };
    }
}