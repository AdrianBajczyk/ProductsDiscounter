using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Browsers;

public class ProductBrowser : IProductBrowser
{
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
