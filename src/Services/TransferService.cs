using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Services;

public class TransferService : ITransferService
{

    public bool IsValidPlayer(User payer)
    {
        var userType = payer.UserType;

        return userType switch
        {
            UserType.COMMON => true,
            UserType.MERCHANDISE => false,
            _ => throw new Exception("Invalid UserType")
        };
    }

    (User newPayer, User newPayee) ITransferService.GetTheUpdatedEntities(TransferDTO transferDTO)
    {
        var newPayer = transferDTO.Payer;
        var newPayee = transferDTO.Payee;

        newPayer.RemoveMoney(transferDTO.TransactionValue);
        newPayee.AddMoney(transferDTO.TransactionValue);

        return (newPayer, newPayee);
    }
}