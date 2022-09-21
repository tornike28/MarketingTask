using Application.ProductFeature.Commands.CreateProduct;
using Application.Shared;
using Microsoft.AspNetCore.Mvc;
using Utility;

namespace MarketingTask.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly IQueryExecutor _queryExecutor;
        public ProductController(
            ICommandExecutor commandExecutor,
            IQueryExecutor queryExecutor)
        {
            _commandExecutor = commandExecutor;
            _queryExecutor = queryExecutor;
        }

        [HttpPost]
        public async Task<CommandExecutionResult> CreateProduct([FromBody] CreateProductCommand command) =>
            await _commandExecutor.Execute(command);
    }
}
