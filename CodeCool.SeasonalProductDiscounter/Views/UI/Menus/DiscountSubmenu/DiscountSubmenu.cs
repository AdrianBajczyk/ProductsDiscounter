using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;
using CodeCool.SeasonalProductDiscounter.Views.UI.Printer;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Menus.DiscountSubmenu;

public class DiscountSubmenu : IDiscountSubmenu
{
    private readonly IUIGetter _uIGetter;
    private readonly IUIPrinter _uIPrinter;
    private readonly IDiscountProvider _discountProvider;

    public DiscountSubmenu(IUIGetter uIGetter, IUIPrinter uIPrinter, IDiscountProvider discountProvider)
    {
        _uIGetter = uIGetter;
        _uIPrinter = uIPrinter;
        _discountProvider = discountProvider;
    }

    public void Run()
    {
        _uIPrinter.PrintDiscounts(_discountProvider.Discounts);
        _uIGetter.GetKeyToContinue();
    }
}