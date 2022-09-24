using MediatR;
using Utility;

namespace Application.Features.ProductFeature.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CommandExecutionResult>
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
