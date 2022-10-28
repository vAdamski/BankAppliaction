using BankApplication.Application.Common.Interfaces;
using BankApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Persistance
{
    public class BankDbContext : DbContext, IBankDbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options): base(options)
        {

        }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<CashMachine> CashMachines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.SeedData();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
