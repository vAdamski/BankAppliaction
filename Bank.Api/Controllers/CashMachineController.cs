using BankApplication.Application.BankMachine.Commands.CashOut;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Api.Controllers
{
    [Route("api/cashMachine")]
    public class CashMachineController : BaseController
    {
        [HttpPatch]
        public async Task<ActionResult> Cashout([FromBody] CashOutCommand cashOutCommand)
        {
            var response = await Mediator.Send(cashOutCommand);

            return Ok(response);
        }
    }
}
