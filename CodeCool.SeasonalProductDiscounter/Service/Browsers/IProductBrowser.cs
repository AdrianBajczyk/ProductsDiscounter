using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Browsers;

public interface IProductBrowser
{
    IEnumerable<Product> GetProductsFromSpecificSeason(IEnumerable<Product> products, Season season);
    IEnumerable<Product> GetProductsWithSpecificColor(IEnumerable<Product> products, Color color);
    IEnumerable<Product> GetProductsWithNameContainingGivenString(IEnumerable<Product> products, string phrase);

    IEnumerable<Product> GetByPriceSmallerThan(IEnumerable<Product> products, double price);
    IEnumerable<Product> GetByPriceGreaterThan(IEnumerable<Product> products, double price);
    IEnumerable<Product> GetByPriceRange(IEnumerable<Product> products, PriceRange priceRange);

    IEnumerable<IGrouping<string, Product>> GroupByName(IEnumerable<Product> products);
    IEnumerable<IGrouping<Color, Product>> GroupByColor(IEnumerable<Product> products);
    IEnumerable<IGrouping<Season, Product>> GroupBySeason(IEnumerable<Product> products);
    IEnumerable<IGrouping<PriceRange, Product>> GroupByPriceRange(IEnumerable<Product> products);


    IEnumerable<Product> SortAscendingByPrice(IEnumerable<Product> products);
    IEnumerable<Product> SortDescendingByPrice(IEnumerable<Product> products);
    IEnumerable<Product> SortAscendingByName(IEnumerable<Product> products);
    IEnumerable<Product> SortDescendingByName(IEnumerable<Product> products);

}
