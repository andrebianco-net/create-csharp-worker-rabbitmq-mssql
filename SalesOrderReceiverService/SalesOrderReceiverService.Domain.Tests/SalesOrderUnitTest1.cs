using FluentAssertions;
using SalesOrderReceiverService.Domain.Entities;
namespace SalerOrderReceiverService.Domain.Tests
{
    public class SalesOrderUnitTest1
    {
        [Fact]
        public void CreateSalesOrder_WithValidParameters_ResultObjectValid()
        {
            //Arrange
            decimal total = decimal.Parse("100.5");
            DateTime soldAt = DateTime.Now;
            int customerId = 1; 
            int categoryId = 1;
            int paymentTypeId = 2;

            //Act
            Action action = () => new SalesOrder(total, soldAt, customerId, categoryId, paymentTypeId);

            //Assert
            action.Should()
                  .NotThrow<SalesOrderReceiverService.Domain.Validation.DomainExceptionValidation>();
        }
        
        [Fact]
        public void CreateSalesOrder_WithInvalidParameters_ResultObjectInvalid()
        {
            //Arrange
            decimal total = decimal.Parse("0");
            DateTime soldAt = DateTime.Now;
            int customerId = 1; 
            int categoryId = 1;
            int paymentTypeId = 2;

            //Act
            Action action = () => new SalesOrder(total, soldAt, customerId, categoryId, paymentTypeId);

            //Assert
            action.Should()
                  .Throw<SalesOrderReceiverService.Domain.Validation.DomainExceptionValidation>()
                  .WithMessage("Invalid total value");                    
        }
        
    }
}