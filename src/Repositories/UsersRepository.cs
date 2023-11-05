using System.Collections.Immutable;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Repositories;

public class UserRepository : IRepository<User>
{
    readonly PicpayDesafioBackendContext context;
    public UserRepository(PicpayDesafioBackendContext ctx)
        => this.context = ctx;

    public async Task<bool> Create(User entity)
    {
        try
        {
            await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public async Task<bool> Update(User entity)
    {
        try
        {
            context.Users.Update(entity);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public bool UpdateNoSave(User entity)
    {
        try
        {
            context.Users.Update(entity);
            return true;
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public async Task<bool> Delete(User entity)
    {
        try
        {
            context.Users.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public async Task<List<User>> Filter(Expression<Func<User, bool>> expression)
    {
        try
        {
            var data = await context.Users.Where(expression).ToListAsync();
            return data;
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }
}