using System;
using BankApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankApplication.Persistance
{
    public static class Seed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CashMachine>(cm =>
            {
                cm.HasData(new CashMachine()
                {
                    Id = 1,
                    Banknote200 = 5,
                    Banknote100 = 5,
                    Banknote50 = 5,
                    Banknote20 = 5,
                    Banknote10 = 5
                });
            });

            modelBuilder.Entity<BankAccount>(ba =>
            {
                ba.HasData(new BankAccount()
                {
                    Id = 1,
                    AccountNumber = "3019075149919263436240",
                    AccountBalance = 7654
                });
            });
        }
    }
}

