using Application.Shared;
using Domain.Aggregates.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Application.ProductFeature.Commands.CreateProduct
{
    public class CreateProductCommand : Command
    {
        public CreateProductRequest Product { get; set; }

        public override async Task<CommandExecutionResult> ExecuteAsync()
        {
            var product = new Product(
                                          Product.Name,
                                          Product.Code,
                                          Product.Price);


            return await ProductRepository.CreateProduct(product);
        }
    }
}
