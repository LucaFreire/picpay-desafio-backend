
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using picpay_desafio_backend.Model;

namespace picpay_desafio_backend.Respositories;

public class TransactionsRespository : IRepository<Transaction>
{
    private PicpayDesafioBackendContext context;
    public TransactionsRespository(PicpayDesafioBackendContext ctx)
        => this.context = ctx;

    public async Task<bool> Create(Transaction entity)
    {
        try
        {
            await context.Transactions.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> Delete(Transaction entity)
    {
        try
        {
            context.Transactions.Remove(entity);
            await context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> Update(Transaction entity)
    {
        try
        {
            context.Transactions.Update(entity);
            await context.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            return false;
        }
        return true;
    }
    
    public async Task<List<Transaction>> Filter(Expression<Func<Transaction, bool>> expression)
    {
        var data = await context.Transactions.Where(expression).ToListAsync();
        return data; 
    }
}