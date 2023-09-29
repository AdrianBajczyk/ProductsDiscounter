using CodeCool.SeasonalProductDiscounter.Extensions;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Model.Enums;

namespace CodeCool.SeasonalProductDiscounter.Model.Discounts;

public record SeasonalDiscount(string Name, int Rate) : IDiscount
{

    public bool Accepts(Product product, DateTime date)
{
        Season currentSeason = SeasonExtensions.GetSeason(date);


        if (Rate == 10)
    {

        return product.Season == SeasonExtensions.Shift(currentSeason, 1) ||
               product.Season == SeasonExtensions.Shift(currentSeason, -1);
    }

    
    if (Rate == 20)
    {
        
        return product.Season == SeasonExtensions.Shift(currentSeason, 2) ||
               product.Season == SeasonExtensions.Shift(currentSeason, -2);
    }

    
    return false;
}

    public override string ToString()
    {
        return $"{nameof(Name)}: {Name}, " +
               $"{nameof(Rate)}: {Rate}, ";

    }
}
