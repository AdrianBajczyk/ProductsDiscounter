using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Extensions;
using CodeCool.SeasonalProductDiscounter.Model.Enums;
using System.Diagnostics;

namespace CodeCool.SeasonalProductDiscounter.Model.Discounts;

public interface IDiscount
{
    bool Accepts(Product product, DateTime date);

    string Name { get; }

    int Rate { get; }

    
}
