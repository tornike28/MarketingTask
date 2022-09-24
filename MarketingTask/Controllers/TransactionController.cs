using Application.Features.TransactionFeature.Commands.AddDistributorTransaction;
using Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace MarketingTask.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TransactionController
    {
        private readonly IMediator _mediator;
        private readonly IQueryExecutor _queryExecutor;
        public TransactionController(
            IMediator mediator,
            IQueryExecutor queryExecutor)
        {
            _mediator = mediator;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<CommandExecutionResult> AddDistributorTransaction([FromBody] AddDistributorTransactionCommand request) =>
            await _mediator.Send(request);
    }
}
