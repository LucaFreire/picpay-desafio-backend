using Microsoft.EntityFrameworkCore;
using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Services;

public class TypeUserService : ITypeUserService
{
    private PicpayDesafioBackendContext context;
    public TypeUserService(PicpayDesafioBackendContext ctx)
        => this.context = ctx;

    public string GetUserType(int userId)
    {
        var query =
            from user in context.Users
            join userType in context.TypeUsers
                on user.UserType equals userType.TypeId
            where user.UserId == userId
            select userType.TypeName;

        return query.ToString();
    }

    public bool IsUserAuthorizedToTransfer(TypeUser typeUser)
    {
        if (Convert.ToBoolean(typeUser))
            return true;
        return false;
    }
}
