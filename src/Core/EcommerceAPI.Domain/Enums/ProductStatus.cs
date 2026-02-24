namespace EcommerceAPI.Domain.Enums
{
    public enum ProductStatus
    {
        Draft = 0, // Product created but not visible to customers
        Active = 1, // Product is available for purchase
        OutOfStock = 2, // Product cannot be purchased temporarily
        Discontinued = 3, // Product is permanently removed from catalog
    }
}
