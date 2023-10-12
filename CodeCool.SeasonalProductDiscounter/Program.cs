using CodeCool.SeasonalProductDiscounter.Service.Browsers;
using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Products;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;
using CodeCool.SeasonalProductDiscounter.Views.UI;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;

namespace CodeCool.SeasonalProductDiscounter;

class Program
{
    static void Main(string[] args)
    {

        IProductProvider productProvider = new ProductProvider();
        IDiscountProvider discountProvider = new DiscountProvider();
        IDiscounterService discountService = new DiscountService(discountProvider);
        ILogger logger = new ConsoleLogger();
        IProductBrowser productBrowser = new ProductBrowser();
        IOffersBrowser offersBrowser = new OffersBrowser();
        IUIGetter uIGetter = new UIGetter(logger);

        var userInterface = new SeasonalProductDiscounterUi
            (
            productProvider,
            discountProvider,
            discountService, 
            logger, 
            productBrowser,
            offersBrowser,
            uIGetter);

        userInterface.Run();
    }
    
}