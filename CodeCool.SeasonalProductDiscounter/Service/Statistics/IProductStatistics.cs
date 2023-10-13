using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Service.Statistics;

public interface IProductStatistics
{
    int TotalAvailableItems(IEnumerable<Product> products);
    double AveragePriceOfProducts(IEnumerable<Product> products);
    Product TheMostExpensiveProduct(IEnumerable<Product> products);
    Product TheCheapestProduct(IEnumerable<Product> products);
    Color TheMostCommonColor(IEnumerable<Product> products);
    Season TheMostCommonSeasonOfProductUse(IEnumerable<Product> products);
}
