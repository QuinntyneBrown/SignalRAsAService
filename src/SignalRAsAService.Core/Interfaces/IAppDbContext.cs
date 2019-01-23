using SignalRAsAService.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRAsAService.Core.Interfaces
{
    public interface IAppDbContext: IDisposable
    {
        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
