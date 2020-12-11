using BankEventStore.Application.Commands;
using BankEventStore.Application.Commands.CreateAccount;
using BankEventStore.Application.Commands.DepositMoney;
using BankEventStore.Application.Commands.WithdrawMoney;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BankEventStore.Api.Controllers
{
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ICommandDispatcher commandDispatcher;

        public AccountsController(ICommandDispatcher commandDispatcher)
        {
            this.commandDispatcher = commandDispatcher;
        }

        [HttpPost("accounts/create")]
        public async Task<IActionResult> CreateAsync(CreateAccount command)
        {
            await commandDispatcher.DispatchAsync(command);
            return Created($"accounts/{command.AccountId}", null);
        }

        [HttpPost("accounts/deposit")]
        public async Task<IActionResult> DepositMoneyAsync(DepositMoney command)
        {
            await commandDispatcher.DispatchAsync(command);
            return Ok();
        }

        [HttpPost("accounts/withdraw")]
        public async Task<IActionResult> WithdrawAsync(WithdrawMoney command)
        {
            await commandDispatcher.DispatchAsync(command);
            return Ok();
        }
    }
}
