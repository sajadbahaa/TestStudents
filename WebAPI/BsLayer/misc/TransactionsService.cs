using BsLayer.misc;
using DTLayer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

public class TransactionService : ITransactionService
{
    private readonly AppDbContext _context;
    private IDbContextTransaction? _transaction;

    public TransactionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task BeginTransactionAsync()
    {
        if (_transaction == null)
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }
    }

    public async Task CommitAsync()
    {
        if (_transaction != null)
        {
            await _context.SaveChangesAsync();   // يحفظ كل التغييرات
            await _transaction.CommitAsync();
            await DisposeAsync(); // ينهي الـ transaction
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await DisposeAsync(); // ينهي الـ transaction
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_transaction != null)
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
}

