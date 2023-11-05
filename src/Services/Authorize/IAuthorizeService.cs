using System.Runtime.CompilerServices;

namespace picpay_desafio_backend.Services;

public interface IAuthorizeService
{
    string ServiceURL { get; set; }
    Task<bool> Authorized();
}