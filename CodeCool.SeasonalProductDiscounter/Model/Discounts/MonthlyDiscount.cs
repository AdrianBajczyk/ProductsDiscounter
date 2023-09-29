using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Model.Discounts;

public record MonthlyDiscount(string name, int rate) : IDiscount
{
    public string Name => name;

    public int Rate => rate;


    public bool Accepts(Product product, DateTime date)
    {
        return product.Season == Enums.Season.Winter || product.Season == Enums.Season.Summer;
    }
}
