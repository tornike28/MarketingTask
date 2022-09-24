using Application.Shared;
using Domain.Aggregates.ProductAggregate;
using Domain.Aggregates.ProductAggregate.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Application.Features.ProductFeature.Commands.CreateProduct
{
    public class CreateProductCommandHandler : CommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository ProductRepository;

        public CreateProductCommandHandler(IServiceProvider serviceProvider, IProductRepository productRepository) : base(serviceProvider)
        {
            ProductRepository = productRepository;
        }


    public override async Task<CommandExecutionResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(
                                      request.Name,
                                      request.Code,
                                      request.Price);


        return await ProductRepository.CreateProduct(product);
    }
}
}
