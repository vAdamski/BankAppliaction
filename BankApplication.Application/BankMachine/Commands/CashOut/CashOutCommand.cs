using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Application.BankMachine.Commands.CashOut
{
    public class CashOutCommand : IRequest<List<int>>
    {
        public int CashMachineNumber { get; set; }
        public string AccountNumber { get; set; }
        public int AmountOfCashout { get; set; }
    }
}
