using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Browsers;

public interface IProductBrowser
{
    IEnumerable<Product> GetProductsFromSpecificSeason(IEnumerable<Product> products, Season season);

    IEnumerable<Product> GetProductsWithSpecificColor(IEnumerable<Product> products, Color color);

    IEnumerable<Product> GetProductsWithNameContainingGivenString(IEnumerable<Product> products, string phrase);

    IEnumerable<Product> SortAscendingByPrice(IEnumerable<Product> products);

    IEnumerable<Product> SortDescendingByPrice(IEnumerable<Product> products);

    IEnumerable<Product> SortAscendingByName(IEnumerable<Product> products);

    IEnumerable<Product> SortDescendingByName(IEnumerable<Product> products);

}
