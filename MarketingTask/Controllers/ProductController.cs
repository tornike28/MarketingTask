using Application.Features.ProductFeature.Commands.CreateProduct;
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
        public ProductController(
            IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<CommandExecutionResult> CreateProduct([FromBody] CreateProductCommand command) =>
            await _mediator.Send(command);
    }
}
