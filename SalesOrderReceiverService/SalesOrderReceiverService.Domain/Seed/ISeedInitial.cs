namespace SalerOrderReceiverService.Domain.Seed
{
    public interface ISeedInitial
    {
        void SeedCustomers();
        void SeedCategories();
        void SeedProducts();
        void SeedPaymentType();
    }
}