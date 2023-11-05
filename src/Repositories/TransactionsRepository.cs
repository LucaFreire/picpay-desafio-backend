
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Repositories;

public class TransactionsRepository : IRepository<Transaction>
{
    readonly PicpayDesafioBackendContext context;
    public TransactionsRepository(PicpayDesafioBackendContext ctx)
        => context = ctx;

    public async Task<bool> Create(Transaction entity)
    {
        try
        {
            var x = await context.Transactions.AddAsync(entity);
            var xz = await context.SaveChangesAsync();
         
            return true;
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public async Task<bool> Delete(Transaction entity)
    {
        try
        {
            context.Transactions.Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public async Task<bool> Update(Transaction entity)
    {
        try
        {
            context.Transactions.Update(entity);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public bool UpdateNoSave(Transaction entity)
    {
        try
        {
            context.Transactions.Update(entity);
            return true;
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }

    public async Task<List<Transaction>> Filter(Expression<Func<Transaction, bool>> expression)
    {
        try
        {
            var data = await context.Transactions.Where(expression).ToListAsync();
            return data;
        }
        catch (Exception error)
        {
            throw new Exception(error.Message);
        }
    }
}