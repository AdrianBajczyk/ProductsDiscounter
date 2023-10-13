using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Statistics;

public class ProductStatistics : IProductStatistics
{
    public double AveragePriceOfProducts(IEnumerable<Product> products)
    {
        var averagePrice = products.Average(x => x.Price);
        var roundedPrice = Math.Round(averagePrice, 2);
        return roundedPrice;
    }

    public Product TheCheapestProduct(IEnumerable<Product> products)
    {
        var minPrice = products.Min(p => p.Price);
        return products.First(p => p.Price == minPrice);
    }

    public Color TheMostCommonColor(IEnumerable<Product> products)
    {
        return products
                       .GroupBy(p => p.Color)
                       .OrderByDescending(group => group.Count())
                       .First()
                       .Key;
    }

    public Season TheMostCommonSeasonOfProductUse(IEnumerable<Product> products)
    {
        return products
                       .GroupBy(p => p.Season)
                       .OrderByDescending(group => group.Count())
                       .First()
                       .Key;
    }

    public Product TheMostExpensiveProduct(IEnumerable<Product> products)
    {
        var maxPrice = products.Max(p => p.Price);
        return products.First(p => p.Price == maxPrice);
    }

    public int TotalAvailableItems(IEnumerable<Product> products)
    {
        return products.Count();
    }
}
