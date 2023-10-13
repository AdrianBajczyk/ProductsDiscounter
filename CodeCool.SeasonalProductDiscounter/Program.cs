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
        ILogger logger = new ConsoleLogger();
        IProductBrowser productBrowser = new ProductBrowser();
        IOffersBrowser offersBrowser = new OffersBrowser();
        IProductStatistics productStatistics = new ProductStatistics();
        IUIPrinter uIPrinter = new UIPrinter(logger);
        IUIGetter uIGetter = new UIGetter(logger);
        IDiscountSubmenu discountSubmenu = new DiscountSubmenu(uIGetter,uIPrinter, discountProvider);
        IStatisticsSubmenu statisticsSubmenu = new StatisticsSubmenu(logger, uIGetter, productStatistics, productProvider);
        IOffersSubmenu offersSubmenu = new OffersSubmenu(logger, uIGetter, uIPrinter, discountService, productProvider, offersBrowser);
        ICatalogSubmenu catalogSubmenu = new CatalogSumbenu(logger, uIGetter, uIPrinter, productProvider, productBrowser);


        var userInterface = new SeasonalProductDiscounterUi
            (catalogSubmenu,
            offersSubmenu,
            statisticsSubmenu,
            discountSubmenu,
            logger,
            uIGetter);

        userInterface.Run();
    }
    
}