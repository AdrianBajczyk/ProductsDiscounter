using CodeCool.SeasonalProductDiscounter.Model.Discounts;
using CodeCool.SeasonalProductDiscounter.Model.Enums;
namespace CodeCool.SeasonalProductDiscounter.Service.Discounts;

public class DiscountProvider : IDiscountProvider
{
    public IEnumerable<IDiscount> Discounts { get; }

    public DiscountProvider()
    {
        Discounts = GetDiscounts();
    }
    private static IEnumerable<IDiscount>GetDiscounts() 
    {
        return new List<IDiscount>() 
        {
            new MonthlyDiscount("Summer Kick-off", 10, Season.Summer),
            new MonthlyDiscount("Winter Sale", 10, Season.Winter),
            new ColorDiscount("Blue Winter", 5, Season.Winter),
            new ColorDiscount("Green Spring", 5, Season.Spring),
            new ColorDiscount("Yellow Summer", 5, Season.Summer),
            new ColorDiscount("Brown Autumn", 5, Season.Autumn),
            new SeasonalDiscount("Sale Discount", 10),
            new SeasonalDiscount("Outlet Discount", 20),
        };
    }
}
