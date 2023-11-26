using SalesOrderReceiverService.Domain.Validation;

namespace SalesOrderReceiverService.Domain.Entities
{
    public class Message
    {
        public SalesOrder SalesOrder { get; private set; }

        public List<SalesOrderItem> SalesOrderItems { get; private set; }

        public Message(SalesOrder salesOrder, List<SalesOrderItem> salesOrderItems)
        {
            ValidateDomain(salesOrder, salesOrderItems);
        }

        private void ValidateDomain(SalesOrder salesOrder, List<SalesOrderItem> salesOrderItems)
        {
            DomainExceptionValidation.When(salesOrder == null, "Invalid salesOrder.");
            DomainExceptionValidation.When(salesOrderItems.Count <= 0, "Invalid quantity for salesOrderItems.");

            SalesOrder = salesOrder;
            SalesOrderItems = salesOrderItems;
        }
    }
}