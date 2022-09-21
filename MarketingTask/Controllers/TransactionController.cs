using Application.Shared;
using Application.TransactionFeature.Commands.AddDistributorTransaction;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace MarketingTask.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TransactionController
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;
        public TransactionController(
            ICommandExecutor commandExecutor,
            IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<CommandExecutionResult> AddDistributorTransaction([FromBody] AddDistributorTransactionCommand command) =>
            await _commandExecutor.Execute(command); 
    }
}
