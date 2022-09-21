using Application.DistributorFeature.DistributorCommands.CreateDistributor;
using Application.DistributorFeature.DistributorQueries;
using Application.Shared;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace MarketingTask.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DistributorController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;
        public DistributorController(
            ICommandExecutor commandExecutor,
            IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<CommandExecutionResult> CreateDistributor([FromBody] CreateDistributorCommand command) =>
            await _commandExecutor.Execute(command);

        [HttpGet]
        public async Task<QueryExecutionResult<GetDistributorsQueryResult>> GetDistributors([FromQuery] GetDistributorsQuery query) =>
          await _queryExecutor.Execute<GetDistributorsQuery, GetDistributorsQueryResult>(query);
        
    }
}
