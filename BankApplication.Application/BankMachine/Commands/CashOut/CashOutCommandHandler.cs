using BankApplication.Application.Common.Interfaces;
using BankApplication.Domain.Common;
using BankApplication.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication.Application.BankMachine.Commands.CashOut
{
    public class CashOutCommandHandler : IRequestHandler<CashOutCommand, List<int>>
    {
        private IBankDbContext _context;
        public CashOutCommandHandler(IBankDbContext context)
        {
            _context = context;
        }

        public async Task<List<int>> Handle(CashOutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //Check amount to cashout is valid
                if (request.AmountOfCashout % 10 != 0) throw new BadRequestException($"Entered amount to cashout is invalid. Entered amount = {request.AmountOfCashout}.");

                // Get data from database
                var account = await _context.BankAccounts.FirstOrDefaultAsync(x => x.AccountNumber == request.AccountNumber, cancellationToken);
                var cashMachine = await _context.CashMachines.FirstOrDefaultAsync(x => x.Id == request.CashMachineNumber, cancellationToken);

                // Validate data
                if (account == null)
                    throw new BadRequestException($"Bank account with number {request.AccountNumber} not found.");

                if (account.AccountBalance < request.AmountOfCashout)
                    throw new BadRequestException($"Not enough money on bank account!");

                //Create dictionary with key = banknote amount, value = amount of banknotes
                var cashMachineContainer = new Dictionary<int, int>();
                foreach (Banknote banknote in Enum.GetValues<Banknote>().OrderByDescending(b => b))
                {
                    var x = cashMachine.GetType().GetProperty(banknote.ToString()).GetValue(cashMachine, null);
                    cashMachineContainer.Add((int)banknote, (int)x);
                }

                // Sum cashInMachine
                var cashInMachine = cashMachineContainer.Sum(x => x.Value * x.Key);

                // Validate if posible is cashout money
                if (request.AmountOfCashout > cashInMachine)
                    throw new BadRequestException($"Not enough money in cash machine.");

                // Cashout money process 
                var listBanknoteToCashout = new List<int>();

                listBanknoteToCashout = CashOutAlgorithm(new Dictionary<int, int>(cashMachineContainer), listBanknoteToCashout, request.AmountOfCashout);

                if (listBanknoteToCashout.Count == 0)
                    throw new BadRequestException($"Cash machine can not withdraw cash");

                foreach (var banknote in listBanknoteToCashout)
                {
                    cashMachineContainer[banknote] -= 1;
                }
                
                // Update machine banknote storage, user account and save changes
                account.AccountBalance -= request.AmountOfCashout;
                cashMachine.Banknote200 = cashMachineContainer[200];
                cashMachine.Banknote100 = cashMachineContainer[100];
                cashMachine.Banknote50 = cashMachineContainer[50];
                cashMachine.Banknote20 = cashMachineContainer[20];
                cashMachine.Banknote10 = cashMachineContainer[10];


                _context.CashMachines.Update(cashMachine);
                _context.BankAccounts.Update(account);

                try
                {
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateException)
                {
                    throw new DbUpdateException("Saving to database error!");
                }

                return listBanknoteToCashout;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        // It's not a perfect solution, but Keep It Simple Stupid 
        private List<int> CashOutAlgorithm(Dictionary<int, int> cashMachineStorage, List<int> banknotesToCashout,
            int amountToCashout)
        {
            if (banknotesToCashout.Sum() == amountToCashout || cashMachineStorage.Count == 0) return banknotesToCashout;
            banknotesToCashout.Clear();

            var copy = new Dictionary<int, int>(cashMachineStorage);
            var copyAmountToCashout = amountToCashout;
            foreach (var banknote in copy)
            {
                while (copy[banknote.Key] > 0 && copyAmountToCashout - banknote.Key >= 0)
                {
                    copyAmountToCashout -= banknote.Key;
                    copy[banknote.Key] -= 1;
                    banknotesToCashout.Add(banknote.Key);
                }
            }

            if (copyAmountToCashout != 0)
            {
                cashMachineStorage.Remove(cashMachineStorage.Keys.First());
                return CashOutAlgorithm(cashMachineStorage, banknotesToCashout, amountToCashout);
            }

            return banknotesToCashout;
        }
    }
}