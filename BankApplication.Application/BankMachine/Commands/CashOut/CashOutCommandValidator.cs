using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Application.BankMachine.Commands.CashOut
{
    public class CashOutCommandValidator : AbstractValidator<CashOutCommand>
    {
        public CashOutCommandValidator()
        {
            RuleFor(x => x.CashMachineNumber).GreaterThan(0);
            RuleFor(x => x.AccountNumber).NotEmpty();
            RuleFor(x => x.AmountOfCashout).GreaterThan(0);
        }
    }
}
