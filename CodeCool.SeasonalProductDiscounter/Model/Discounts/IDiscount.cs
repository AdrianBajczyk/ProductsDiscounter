using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Extensions;

namespace CodeCool.SeasonalProductDiscounter.Model.Discounts;

public interface IDiscount
{
    bool Accepts(Product product, DateTime date);

    string Name { get; }

    int Rate { get; }
}
