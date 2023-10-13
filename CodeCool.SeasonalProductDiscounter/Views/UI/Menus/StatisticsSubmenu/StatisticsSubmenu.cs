using CodeCool.SeasonalProductDiscounter.Service.Products;
using CodeCool.SeasonalProductDiscounter.Service.Statistics;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Menus.StatisticsSubmenu;

public class StatisticsSubmenu : IStatisticsSubmenu
{

    private ILogger _logger;
    private IUIGetter _uIGetter;
    private IProductStatistics _productStatistics;
    private IProductProvider _productsProvider;


    public StatisticsSubmenu(ILogger logger, IUIGetter uiGetter, IProductStatistics productStatistics, IProductProvider productsProvider)
    {
        _logger = logger;
        _uIGetter = uiGetter;
        _productStatistics = productStatistics;
        _productsProvider = productsProvider;
    }

    public void Run()
    {
        int select = 0;

        while (select != 7)
        {

            DisplayStatisticsSubenu();
            select = _uIGetter.GetIntFromUser();

            switch (select)
            {
                case 1:
                    _logger.Clear();
                    var totalItems = _productStatistics.TotalAvailableItems(_productsProvider.Products);
                    _logger.NewLine();
                    _logger.LogInfo($"Total available items: {totalItems}");
                    _logger.NewLine();
                    break;
                case 2:
                    _logger.Clear();
                    var averagePrice = _productStatistics.AveragePriceOfProducts(_productsProvider.Products);
                    _logger.NewLine();
                    _logger.LogInfo($"Average price: {averagePrice}");
                    _logger.NewLine();
                    break;
                case 3:
                    _logger.Clear();
                    var theMostExpensiveProduct = _productStatistics.TheMostExpensiveProduct(_productsProvider.Products);
                    _logger.NewLine();
                    _logger.LogInfo($"The most expensive product: {theMostExpensiveProduct.Name} which cost {theMostExpensiveProduct.Price}");
                    _logger.NewLine();
                    break;
                case 4:
                    _logger.Clear();
                    var cheapestProduct = _productStatistics.TheCheapestProduct(_productsProvider.Products);
                    _logger.NewLine();
                    _logger.LogInfo($"Chepset product: {cheapestProduct.Name} which cost {cheapestProduct.Price}");
                    _logger.NewLine();
                    break;
                case 5:
                    _logger.Clear();
                    var theMostCommonColor = _productStatistics.TheMostCommonColor(_productsProvider.Products);
                    _logger.NewLine();
                    _logger.LogInfo($"The most common color is: {theMostCommonColor}");
                    _logger.NewLine();
                    break;
                case 6:
                    _logger.Clear();
                    var theMostCommonSeason = _productStatistics.TheMostCommonSeasonOfProductUse(_productsProvider.Products);
                    _logger.NewLine();
                    _logger.LogInfo($"The most common season use is: {theMostCommonSeason}");
                    _logger.NewLine();
                    break;
                default:
                    _logger.Clear();
                    break;

            }
        }

    }

    private void DisplayStatisticsSubenu()
    {
        _logger.LogInfo("----Products Statistics Menu----");
        _logger.LogInfo("1. Total available items");
        _logger.LogInfo("2. Average price of products");
        _logger.LogInfo("3. The most expensive product");
        _logger.LogInfo("4. The cheapest product");
        _logger.LogInfo("5. The most common color");
        _logger.LogInfo("6. The most common season of product use");
        _logger.LogInfo("7. Back");
        _logger.LogInfo("--------------------------------");
    }

}
