using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Persistance
{
    public class BankDbContextFactory : DesignTimeDbContextFactoryBase<BankDbContext>
    {
        protected override BankDbContext CreateNewInstance(DbContextOptions<BankDbContext> options)
        {
            return new BankDbContext(options);
        }
    }
}
