using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using System.Diagnostics;

namespace CodeCool.SeasonalProductDiscounter.Service.Browsers;

public class ProductBrowser : IProductBrowser
{
    public IEnumerable<Product> GetByPriceGreaterThan(IEnumerable<Product> products, double price)
    {
        return products.Where(p => price < p.Price);
    }

    public IEnumerable<Product> GetByPriceRange(IEnumerable<Product> products, PriceRange priceRange)
    {
        return products.Where(p => priceRange.Minimum < p.Price && priceRange.Maximum > p.Price);
    }

    public IEnumerable<Product> GetByPriceSmallerThan(IEnumerable<Product> products, double price)
    {
        return products.Where(p => price > p.Price);
    }

    public IEnumerable<Product> GetProductsFromSpecificSeason(IEnumerable<Product> products, Season season)
    {
        return products.Where(p => p.Season == season);
    }

    public IEnumerable<Product> GetProductsWithNameContainingGivenString(IEnumerable<Product> products, string phrase)
    {
        return products.Where(p => p.Name.ToLower().Contains(phrase.ToLower()));
    }

    public IEnumerable<Product> GetProductsWithSpecificColor(IEnumerable<Product> products, Color color)
    {
        return products.Where(p => p.Color == color);
    }

    public IEnumerable<IGrouping<Color, Product>> GroupByColor(IEnumerable<Product> products)
    {
        return products.GroupBy(p => p.Color);
    }

    public IEnumerable<IGrouping<string, Product>> GroupByName(IEnumerable<Product> products)
    {
        
        return products.GroupBy(p => p.Name.Split(" ")[1]);
    }

    public IEnumerable<IGrouping<PriceRange, Product>> GroupByPriceRange(IEnumerable<Product> products)
    {
        var minimumPriceRange = new PriceRange(5, 33);
        var averagePriceRange = new PriceRange(34, 66);
        var maximumPriceRange = new PriceRange(67, 100);

        var rangeList = new List<PriceRange>
    {
        minimumPriceRange,
        averagePriceRange,
        maximumPriceRange
    };

        return products.GroupBy(p => rangeList.Find(r => r.Minimum <= p.Price && r.Maximum >= p.Price));
    }

    public IEnumerable<IGrouping<Season, Product>> GroupBySeason(IEnumerable<Product> products)
    {
        return products.GroupBy(p => p.Season);
    }

    public IEnumerable<Product> SortAscendingByName(IEnumerable<Product> products)
    {
        return products.OrderBy(p => p.Name.ToLower());
    }

    public IEnumerable<Product> SortAscendingByPrice(IEnumerable<Product> products)
    {
        return products.OrderBy(p => p.Price);
    }

    public IEnumerable<Product> SortDescendingByName(IEnumerable<Product> products)
    {
        return products.OrderByDescending(p => p.Name.ToLower());
    }

    public IEnumerable<Product> SortDescendingByPrice(IEnumerable<Product> products)
    {
        return products.OrderByDescending(p => p.Price);
    }
}
