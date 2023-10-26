using CodeCool.SeasonalProductDiscounter.Service.Browsers;
using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Products;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.MenuFactory;

public class OffersUIFactory : AbstractMenuFactory
{
    public override AbstractMenu CreateMenu()
    {
        var discountProvider = new DiscountProvider();

        return new OffersSubmenu("Offers Submenu", true, new DiscountService(discountProvider), new OffersBrowser());
    }
}
