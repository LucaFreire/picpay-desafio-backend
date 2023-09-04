namespace picpay_desafio_backend.Services;

public interface ITypeUserService
{
    bool IsUserAuthorizedToTransfer(TypeUser typeUser);
    string GetUserType(int? userId);
}

public enum TypeUser
{
    Seller = 0,
    Common = 1
}
