using Application.Features.TransactionFeature.Commands.AddDistributorTransaction;
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
        public TransactionController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<CommandExecutionResult> AddTransaction([FromBody] AddTransactionCommand request) =>
            await _mediator.Send(request);
    }
}
