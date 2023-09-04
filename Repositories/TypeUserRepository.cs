using Microsoft.EntityFrameworkCore;
using picpay_desafio_backend.Model;
using System.Linq.Expressions;

namespace picpay_desafio_backend.Respositories;

public class TypeUserRepository : IRepository<TypeUser>
{
    private PicpayDesafioBackendContext context;
    public TypeUserRepository(PicpayDesafioBackendContext ctx)
        => this.context = ctx;

    public async Task<bool> Create(TypeUser entity)
    {
        try
        {
            await context.TypeUsers.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> Delete(TypeUser entity)
    {
        try
        {
            context.TypeUsers.Remove(entity);
            await context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> Update(TypeUser entity)
    {
        try
        {
            context.TypeUsers.Update(entity);
            await context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            return false;
        }
        return true;
    }

    public async Task<List<TypeUser>> Filter(Expression<Func<TypeUser, bool>> expression)
    {
        try
        {
            var data = await context.TypeUsers.Where(expression).ToListAsync();
            return data;
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
