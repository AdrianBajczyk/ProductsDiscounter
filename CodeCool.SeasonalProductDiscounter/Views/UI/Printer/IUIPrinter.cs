using CodeCool.SeasonalProductDiscounter.Model.Discounts;
using CodeCool.SeasonalProductDiscounter.Model.Offers;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Printer;

public interface IUIPrinter
{
    void PrintProducts(IEnumerable<Product> products);

    void PrintGroupedProducts<Tkey>(IEnumerable<IGrouping<Tkey, Product>> groupedProducts);

    void PrintDiscounts(IEnumerable<IDiscount> discounts);

    void PrintOffers(IEnumerable<Offer> offers);
}
