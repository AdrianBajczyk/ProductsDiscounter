using CodeCool.SeasonalProductDiscounter.Service.Browsers;
using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Products;
using CodeCool.SeasonalProductDiscounter.Service.Statistics;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus.StatisticsSubmenu;
using CodeCool.SeasonalProductDiscounter.Views.UI;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus.DiscountSubmenu;
using CodeCool.SeasonalProductDiscounter.Views.UI.Printer;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus.OffersSubmenu;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus.CatalogSubmenu;

namespace CodeCool.SeasonalProductDiscounter;

class Program
{
    static void Main(string[] args)
    {
        IProductProvider productProvider = new RandomProductGenerator();
        IDiscountProvider discountProvider = new DiscountProvider();
        IDiscounterService discountService = new DiscountService(discountProvider);

        var loggers = new SortedList<string, ILogger>
        {
            { "consoleLogger", new ConsoleLogger()},
            { "fileLogger", new FileLogger()} 
        };


        IProductBrowser productBrowser = new ProductBrowser();
        IOffersBrowser offersBrowser = new OffersBrowser();
        IProductStatistics productStatistics = new ProductStatistics();
        IUIPrinter uIPrinter = new UIPrinter(loggers);
        IUIGetter uIGetter = new UIGetter(loggers);
        IDiscountSubmenu discountSubmenu = new DiscountSubmenu(uIGetter,uIPrinter, discountProvider);
        IStatisticsSubmenu statisticsSubmenu = new StatisticsSubmenu(loggers, uIGetter,uIPrinter, productStatistics, productProvider);
        IOffersSubmenu offersSubmenu = new OffersSubmenu(loggers, uIGetter, uIPrinter, discountService, productProvider, offersBrowser);
        ICatalogSubmenu catalogSubmenu = new CatalogSumbenu(loggers, uIGetter, uIPrinter, productProvider, productBrowser);


        var userInterface = new SeasonalProductDiscounterUi
            (catalogSubmenu,
            offersSubmenu,
            statisticsSubmenu,
            discountSubmenu,
            loggers,
            uIGetter,
            uIPrinter);

        userInterface.Run();
    }
    
}