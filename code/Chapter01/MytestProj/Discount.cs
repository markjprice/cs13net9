using BestInTownProducts;
using System;

public class Discount
{
    public int Id { get; set; }
    public string Code { get; set; }
    public decimal Percentage { get; set; }
    public DateTime ExpiryDate { get; set; }

    public bool IsValid()
    {
        return DateTime.Now <= ExpiryDate;
    }
}

public class DiscountService
{
    public void ApplyDiscount(Product product, string discountCode)
    {
        // Implement discount application logic
        throw new NotImplementedException();
    }
}
