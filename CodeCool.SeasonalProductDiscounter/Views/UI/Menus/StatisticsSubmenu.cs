using CodeCool.SeasonalProductDiscounter.Service.Products;
using CodeCool.SeasonalProductDiscounter.Service.Statistics;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;
using CodeCool.SeasonalProductDiscounter.Views.UI.Printer;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Menus;

public class StatisticsSubmenu : AbstractMenu
{
    private readonly IProductStatistics _productStatistics;


    public StatisticsSubmenu(string title,bool needsAutification,IProductStatistics productStatistics)
        :base(title, needsAutification)
    {
        _productStatistics = productStatistics;
    }

    public override void Display()
    {
        foreach(var log in _loggers) 
        {
            log.Value.LogInfo(Title);
        }
        Run();
    }

    public  void Run()
    {
        int select = 0;

        while (select != 7)
        {

            DisplayStatisticsSubenu();
            select = _uIGetter.GetIntFromUser();

            switch (select)
            {
                case 1:
                    _loggers["consoleLogger"].Clear();
                    var totalItems = _productStatistics.TotalAvailableItems(_productProvider.Products);
                    LogHeader("Total available items", totalItems);
                    break;
                case 2:
                    _loggers["consoleLogger"].Clear();
                    var averagePrice = _productStatistics.AveragePriceOfProducts(_productProvider.Products);
                    LogHeader("Average price:", averagePrice);
                    break;
                case 3:
                    _loggers["consoleLogger"].Clear();
                    var theMostExpensiveProduct = _productStatistics.TheMostExpensiveProduct(_productProvider.Products);
                    LogHeader("The most expensive product:", $"{theMostExpensiveProduct.Name} which cost {theMostExpensiveProduct.Price}");
                    break;
                case 4:
                    _loggers["consoleLogger"].Clear();
                    var cheapestProduct = _productStatistics.TheCheapestProduct(_productProvider.Products);
                    LogHeader("Chepset product:", $"{cheapestProduct.Name} which cost {cheapestProduct.Price}");
                    break;
                case 5:
                    _loggers["consoleLogger"].Clear();
                    var theMostCommonColor = _productStatistics.TheMostCommonColor(_productProvider.Products);
                    LogHeader("The most common color is:", theMostCommonColor);
                    break;
                case 6:
                    _loggers["consoleLogger"].Clear();
                    var theMostCommonSeason = _productStatistics.TheMostCommonSeasonOfProductUse(_productProvider.Products);
                    LogHeader("The most common season use is:", theMostCommonSeason);
                    break;
                default:
                    _loggers["consoleLogger"].Clear();
                    break;

            }
        }

    }

    private void LogHeader(string textInfo, dynamic value)
    {
        foreach (var logger in _loggers)
        {
            logger.Value.NewLine();
            logger.Value.LogInfo($"{textInfo} {value}");
            logger.Value.NewLine();
        }

    }

    private void DisplayStatisticsSubenu()
    {
        var menuContent = new List<string>();

        menuContent.Add("----Products Statistics Menu----");
        menuContent.Add("1. Total available items");
        menuContent.Add("2. Average price of products");
        menuContent.Add("3. The most expensive product");
        menuContent.Add("4. The cheapest product");
        menuContent.Add("5. The most common color");
        menuContent.Add("6. The most common season of product use");
        menuContent.Add("7. Back");
        menuContent.Add("--------------------------------");

        _uIPrinter.PrintList(menuContent);
    }

    
}
