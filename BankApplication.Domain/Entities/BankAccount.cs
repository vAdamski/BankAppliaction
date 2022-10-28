using BankApplication.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Domain.Entities
{
    public class BankAccount : AuditableEntity
    {
        public string AccountNumber { get; set; }
        public decimal AccountBalance { get; set; }
    }
}
