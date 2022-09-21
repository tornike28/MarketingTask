using Domain.Aggregates.DistributorAggregate;
using Domain.Aggregates.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace Domain.Aggregates.TransactionAggregate
{
    public class Transaction : AggregateRoot
    {
        public Transaction(
            Distributor distributor,
            DateTime saleDate,
            Product product,
            decimal productPrice,
            decimal unitPrice,
            decimal totalPrice)
        {
            Distributor = distributor;
            SaleDate = saleDate;
            Product = product;
            ProductPrice = productPrice;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }

        public virtual Distributor Distributor { get; private set; }
        public DateTime SaleDate { get; private set; }
        public virtual Product Product { get; private set; }
        public decimal ProductPrice { get; private set; }
        public decimal UnitPrice { get; private set; }
        public decimal TotalPrice { get; private set; }
    }
}
