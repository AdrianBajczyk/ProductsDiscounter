using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.MenuFactory;

public class DiscountUIFactory : AbstractMenuFactory
{
    public override AbstractMenu CreateMenu()
    {
        return new DiscountSubmenu("Discounts", false, new DiscountProvider());
    }
}
