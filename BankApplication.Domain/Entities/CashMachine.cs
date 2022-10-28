using BankApplication.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Domain.Entities
{
    public class CashMachine : AuditableEntity
    {
        public int Banknote200 { get; set; }
        public int Banknote100 { get; set; }
        public int Banknote50 { get; set; }
        public int Banknote20 { get; set; }
        public int Banknote10 { get; set; }
    }
}
