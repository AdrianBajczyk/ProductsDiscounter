using CodeCool.SeasonalProductDiscounter.Model.Discounts;
using CodeCool.SeasonalProductDiscounter.Model.Offers;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Printer;

public class UIPrinter : IUIPrinter
{
    private readonly ILogger _logger;
    private List<string[]> _tableContent = new();
    public UIPrinter(ILogger logger)
    {
        _logger = logger;
    }

    public void PrintDiscounts(IEnumerable<IDiscount> discounts)
    {
        foreach (var discount in discounts)
        {
            _tableContent.Add(new string[] { discount.Name, discount.Rate.ToString() }); ;
        }
        _logger.NewLine();
        _logger.LogInfo("This year's promotions:");
        _logger.LogTable(_tableContent, "Name", "Rate");
        _tableContent.Clear();
    }

    public void PrintGroupedProducts<Tkey>(IEnumerable<IGrouping<Tkey, Product>> groupedProducts)
    {
        foreach (var group in groupedProducts)
        {
            _logger.LogInfo(group.Key.ToString());

            PrintProducts(group);
        }
    }

    public void PrintOffers(IEnumerable<Offer> offers)
    {
        _logger.LogInfo("Promotions for choosen date:");
        _logger.NewLine();

        foreach (var offer in offers)
        {
            _tableContent.Add(new string[] { offer.Product.Name, offer.Product.Color.ToString(), offer.Product.Season.ToString(), offer.Product.Price.ToString(), offer.Product.Id.ToString() });
            _logger.LogTable(_tableContent, "Product Name", "Color", "Season", "Price", "Id");
            _tableContent.Clear();


            foreach (var discount in offer.Discounts)
            {
                _tableContent.Add(new string[] { discount.Name, discount.Rate.ToString() });
            }

            _logger.LogTable(_tableContent, "Discounts", "Rate");
            _tableContent.Clear();

            _logger.LogInfo("Price after all discounts: " + offer.Price.ToString());
            _logger.NewLine();
            _logger.NewLine();
        }
        _logger.NewLine();

    }

    public void PrintProducts(IEnumerable<Product> products)
    {
        foreach (var product in products)
        {
            _tableContent.Add(new string[] { product.Name, product.Color.ToString(), product.Season.ToString(), product.Price.ToString(), product.Id.ToString() });
        }
        _logger.NewLine();
        _logger.LogTable(_tableContent, "Name", "Color", "Season", "Price", "Id");
        _tableContent.Clear();
    }
}