using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Domain.Aggregates.ProductAggregate
{
    public class Product : AggregateRoot
    {
        public Product(
            string name,
            string code,
            decimal price)
        {
            Name = name;
            Code = code;
            Price = price;
        }

        public string Name { get; private set; }
        public string Code { get; private set; }
        public decimal Price { get; private set; }
    }
}
