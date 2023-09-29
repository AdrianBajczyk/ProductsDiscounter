using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Extensions;

namespace CodeCool.SeasonalProductDiscounter.Model.Discounts;

public record MonthlyDiscount(string Name, int Rate, Season ValiditySeason) : IDiscount
{

    public bool Accepts(Product product, DateTime date)
    {
        return SeasonExtensions.Contains(ValiditySeason, date) && SeasonExtensions.Contains(product.Season, date);
    }

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, " +
               $"{nameof(Rate)}: {Rate}, ";

    }
}
