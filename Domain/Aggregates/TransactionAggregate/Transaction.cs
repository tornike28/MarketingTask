using Domain.Aggregates.DistributorAggregate;
using Domain.Aggregates.ProductAggregate;
using Utility;

namespace Domain.Aggregates.TransactionAggregate
{
    public class Transaction : AggregateRoot
    {
        public Transaction()
        {

        }

        public Transaction(
            int distributorId,
            string distributorSecondaryId,
            DateTime saleDate,
            int productId,
            double productPrice,
            double unitPrice,
            double totalPrice)
        {
            DistributorId = distributorId;
            DistributorSecondaryId = distributorSecondaryId;
            SaleDate = saleDate;
            ProductId = productId;
            ProductPrice = productPrice;
            UnitPrice = unitPrice;
            TotalPrice = totalPrice;
        }

        public int DistributorId { get; private set; }
        public string DistributorSecondaryId { get; private set; }
        public DateTime SaleDate { get; private set; }
        public int ProductId { get; private set; }
        public double ProductPrice { get; private set; }
        public double UnitPrice { get; private set; }
        public double TotalPrice { get; private set; }
    }
}
