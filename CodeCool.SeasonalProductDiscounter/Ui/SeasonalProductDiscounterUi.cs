using System.Collections;
using CodeCool.SeasonalProductDiscounter.Model.Offers;
using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Logger;
using CodeCool.SeasonalProductDiscounter.Service.Products;

namespace CodeCool.SeasonalProductDiscounter.Ui;

public class SeasonalProductDiscounterUi
{
    private readonly IProductProvider _productProvider;
    private readonly IDiscountProvider _discountProvider;
    private readonly IDiscounterService _discounterService;
    private readonly ILogger _logger;

    public SeasonalProductDiscounterUi(
        IProductProvider productProvider,
        IDiscountProvider discountProvider,
        IDiscounterService discounterService,
        ILogger logger)
    {
        _productProvider = productProvider;
        _discountProvider = discountProvider;
        _discounterService = discounterService;
        _logger = logger;
    }

    public void Run()
    {
        _logger.LogInfo("Welcome to Seasonal Product Discounter!");
        _logger.NewLine();

        PrintCatalog();
        PrintPromotions();

        _logger.LogInfo("Enter a date to see which products are discounted on that date:");
        var date = GetDate();
        _logger.NewLine();

        PrintOffers(date);
    }

    private void PrintCatalog()
    {
        _logger.LogInfo("Current product catalog (without any discounts):");
        PrintEnumerable(_productProvider.Products);
        _logger.NewLine();
    }

    private void PrintPromotions()
    {
        _logger.LogInfo("This year's promotions:");
        PrintEnumerable(_discountProvider.Discounts);
        _logger.NewLine();
    }

    private void PrintOffers(DateTime date)
    {
        var discounted = GetOffers(date);
        PrintEnumerable(discounted);
    }

    private List<Offer> GetOffers(DateTime date)
    {
        List<Offer> discounted = new();
        foreach (var product in _productProvider.Products)
        {
            var offer = _discounterService.GetOffer(product, date);
            if (offer.Discounts.Any())
            {
                discounted.Add(offer);
            }
        }

        return discounted;
    }

    private DateTime GetDate()
    {
        string? input = null;
        DateTime date;

        while (!DateTime.TryParse(input, out date))
        {
            if (input != null)
            {
                _logger.LogError("Invalid date!");
            }

            input = Console.ReadLine();
        }

        return date;
    }

    private void PrintEnumerable(IEnumerable enumerable)
    {
        foreach (var element in enumerable)
        {
            _logger.LogInfo(element.ToString());
        }
    }
}
