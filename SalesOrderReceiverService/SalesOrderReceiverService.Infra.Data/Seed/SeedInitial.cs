using SalerOrderReceiverService.Domain.Interfaces;
using SalerOrderReceiverService.Domain.Seed;
using SalesOrderReceiverService.Domain.Entities;
using SalesOrderReceiverService.Infra.Data.Repositories;
using System;

namespace SalerOrderReceiverService.Infra.Data.Seed
{
    public class SeedInitial : ISeedInitial
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPaymentTypeRepository _paymentTypeRepository;
        private readonly IProductRepository _productRepository;

        public SeedInitial(ICategoryRepository category,
                           ICustomerRepository customer,
                           IPaymentTypeRepository payment,
                           IProductRepository product)
        {
            _categoryRepository = category;
            _customerRepository = customer;
            _paymentTypeRepository = payment;
            _productRepository = product;
        }

        public void SeedCategories()
        {
            string categoryName = "Auto Parts";

            if(!_categoryRepository.CategoryExistsAsync(categoryName).Result)
            {
                Category category = new Category(categoryName);
                _categoryRepository.CreateCategoryAsync(category).Wait();
            }
        }

        public void SeedCustomers()
        {
            string customerName = "Adam";

            if(!_customerRepository.CustomerExistsAsync(customerName).Result)
            {
                Customer customer = new Customer(customerName);
                _customerRepository.CreateCustomerAsync(customer).Wait();
            }
        }

        public void SeedPaymentType()
        {
            string paymentName = "Credit";

            if(!_paymentTypeRepository.PaymentTypeExistsAsync(paymentName).Result)
            {
                PaymentType paymentType = new PaymentType(paymentName);
                _paymentTypeRepository.CreatePaymentTypeAsync(paymentType).Wait();
            }
        }

        public void SeedProducts()
        {
            string productName = "Fittipaldi Wheel 369 22pol";

            if(!_productRepository.ProductExistsAsync(productName).Result)
            {
                Product product = new Product(productName);
                _productRepository.CreateProductAsync(product).Wait();
            }
        }
    }
}