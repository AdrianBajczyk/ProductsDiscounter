using CodeCool.SeasonalProductDiscounter.Model.Discounts;
using CodeCool.SeasonalProductDiscounter.Model.Offers;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Printer;

public class UIPrinter : IUIPrinter
{
    private readonly SortedList<string, ILogger> _loggers;
    private List<string[]> _tableContent = new();
    public UIPrinter(SortedList<string, ILogger> loggers)
    {
        _loggers = loggers;
    }

    public void PrintDiscounts(IEnumerable<IDiscount> discounts)
    {
        foreach (var logger in _loggers)
        {
            foreach (var discount in discounts)
            {
                _tableContent.Add(new string[] { discount.Name, discount.Rate.ToString() }); ;
            }

            logger.Value.NewLine();
            logger.Value.LogInfo("This year's promotions:");
            logger.Value.LogTable(_tableContent, "Name", "Rate");
            _tableContent.Clear();
        }
        
    }

    public void PrintGroupedProducts<Tkey>(IEnumerable<IGrouping<Tkey, Product>> groupedProducts)
    {

        foreach (var logger in _loggers)
        {
            foreach (var group in groupedProducts)
            {
                logger.Value.LogInfo(group.Key.ToString());

                PrintProducts(group);
            } 
        }
    }

    public void PrintList(List<string> menu)
    {
        foreach (var logger in _loggers)
        {
            foreach (var item in menu)
            {
                logger.Value.LogInfo(item);
            }
        }
        
    }

    public void PrintOffers(IEnumerable<Offer> offers)
    {
        foreach (var logger in _loggers)
        {
            logger.Value.LogInfo("Promotions for choosen date:");
            logger.Value.NewLine();

            foreach (var offer in offers)
            {
                _tableContent.Add(new string[] { offer.Product.Name, offer.Product.Color.ToString(), offer.Product.Season.ToString(), offer.Product.Price.ToString(), offer.Product.Id.ToString() });
                logger.Value.LogTable(_tableContent, "Product Name", "Color", "Season", "Price", "Id");
                _tableContent.Clear();


                foreach (var discount in offer.Discounts)
                {
                    _tableContent.Add(new string[] { discount.Name, discount.Rate.ToString() });
                }

                logger.Value.LogTable(_tableContent, "Discounts", "Rate");
                _tableContent.Clear();

                logger.Value.LogInfo("Price after all discounts: " + offer.Price.ToString());
                logger.Value.NewLine();
                logger.Value.NewLine();
            }
            logger.Value.NewLine();
        }
        

    }

    public void PrintProducts(IEnumerable<Product> products)
    {
        foreach (var logger in _loggers)
        {
            foreach (var product in products)
            {
                _tableContent.Add(new string[] { product.Name, product.Color.ToString(), product.Season.ToString(), product.Price.ToString(), product.Id.ToString() });
            }
            logger.Value.NewLine();
            logger.Value.LogTable(_tableContent, "Name", "Color", "Season", "Price", "Id");
            _tableContent.Clear();
        }
        
    }
}

