using Application.Features.DistributorFeature.DistributorCommands.CreateDistributor;
using Application.Features.DistributorFeature.DistributorQueries;
using Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace MarketingTask.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DistributorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IQueryExecutor _queryExecutor;
        public DistributorController(
            IMediator mediator,
            IQueryExecutor queryExecutor)
        {
            _mediator = mediator;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<CommandExecutionResult> CreateDistributor([FromBody] CreateDistributorCommand request) =>
            await _mediator.Send(request);

        [HttpGet]
        public async Task<QueryExecutionResult<GetDistributorsQueryResult>> GetDistributors([FromQuery] GetDistributorsQuery query) =>
          await _queryExecutor.Execute<GetDistributorsQuery, GetDistributorsQueryResult>(query);

    }
}
