namespace picpay_desafio_backend.Services;

public class AuthorizeService : IAuthorizeService
{
    public string ServiceURL { get; set; }
    public async Task<bool> Authorized()
    {
        return true;
    }
}
