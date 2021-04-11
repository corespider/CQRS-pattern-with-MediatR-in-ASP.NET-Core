using CQRS_MediatR.Entity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CQRS_MediatR.Context
{
    public interface ITransactionDbContext
    {
        DbSet<Transaction> Transactions { get; set; }

        Task<int> SaveChangesAsync();
    }
}