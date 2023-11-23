using FluentAssertions;
using SalesOrderReceiverService.Domain.Entities;
namespace SalerOrderReceiverService.Domain.Tests
{
    public class SalesOrderItemUnitTest1
    {
        [Fact]
        public void CreateSalesOrder_WithValidParameters_ResultObjectValid()
        {
            //Arrange
            int salesOrderId = 1;
            int productId = 1;

            //Act
            Action action = () => new SalesOrderItem(salesOrderId, productId);

            //Assert
            action.Should()
                  .NotThrow<SalesOrderReceiverService.Domain.Validation.DomainExceptionValidation>();
        }
        
        [Fact]
        public void CreateSalesOrder_WithInvalidParameters_ResultObjectInvalid()
        {
            //Arrange
            int salesOrderId = 0;
            int productId = 0;

            //Act
            Action action = () => new SalesOrderItem(salesOrderId, productId);

            //Assert
            action.Should()
                  .Throw<SalesOrderReceiverService.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid Id value.");                
        }
        
    }
}