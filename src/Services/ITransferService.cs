using picpay_desafio_backend.Model;
using picpay_desafio_backend.Repositories;

namespace picpay_desafio_backend.Services;


public interface ITransferService
{
    bool IsValidPlayer(User payer);
    (User newPayer, User newPayee) GetTheUpdatedEntities(TransferDTO transferDTO);
}