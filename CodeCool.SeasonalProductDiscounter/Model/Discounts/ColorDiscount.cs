using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Extensions;
using CodeCool.SeasonalProductDiscounter.Model.Enums;

namespace CodeCool.SeasonalProductDiscounter.Model.Discounts
{
    public record ColorDiscount(string Name, int Rate, Season ValiditySeason) : IDiscount
    {
        public bool Accepts(Product product, DateTime date)
        {
            return (SeasonExtensions.Contains(product.Season, date) && SeasonExtensions.Contains(ValiditySeason, date) && product.Color == Color.Blue);
                   
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, " +
                   $"{nameof(Rate)}: {Rate}, ";

        }
    }
}
