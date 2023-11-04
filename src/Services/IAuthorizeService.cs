namespace picpay_desafio_backend.Services;

public interface IAuthorizeService
{
    Task<bool> Authorized();
}