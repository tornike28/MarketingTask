using Application.Features.ProductFeature.Commands.CreateProduct;
using Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace MarketingTask.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IQueryExecutor _queryExecutor;
        public ProductController(
            IMediator mediator,
            IQueryExecutor queryExecutor)
        {
            _mediator = mediator;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<CommandExecutionResult> CreateProduct([FromBody] CreateProductCommand command) =>
            await _mediator.Send(command);
    }
}
