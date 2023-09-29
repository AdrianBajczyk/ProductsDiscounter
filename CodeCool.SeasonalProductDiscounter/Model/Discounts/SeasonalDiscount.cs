using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Model.Discounts;

public record SeasonalDiscount(string name, int rate) : IDiscount
{
    public string Name => name;

    public int Rate => rate;

    public bool Accepts(Product product, DateTime date)
    {
        return (Rate == 10 && product.Season == Extensions.SeasonExtensions.Shift(product.Season,  1)) ||
               (Rate == 10 && product.Season == Extensions.SeasonExtensions.Shift(product.Season, -1)) ||
               (Rate == 20 && product.Season == Extensions.SeasonExtensions.Shift(product.Season,  2)) ||
               (Rate == 20 && product.Season == Extensions.SeasonExtensions.Shift(product.Season, -2));
    }

   
}
