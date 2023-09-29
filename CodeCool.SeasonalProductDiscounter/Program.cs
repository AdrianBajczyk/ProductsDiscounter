using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Logger;
using CodeCool.SeasonalProductDiscounter.Service.Products;
using CodeCool.SeasonalProductDiscounter.Ui;

namespace CodeCool.SeasonalProductDiscounter;

class Program
{
    static void Main(string[] args)
    {

        IProductProvider productProvider = new ProductProvider();
        IDiscountProvider discountProvider = null;
        IDiscounterService discountService = null;
        ILogger logger = new ConsoleLogger();

        var userInterface = new SeasonalProductDiscounterUi(productProvider, discountProvider, discountService, logger);
        userInterface.Run();
    }
    
}