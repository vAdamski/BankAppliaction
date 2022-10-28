using BankApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Application.Common.Interfaces
{
    public interface IBankDbContext
    {
        DbSet<BankAccount> BankAccounts { get; set; }
        DbSet<CashMachine> CashMachines { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
