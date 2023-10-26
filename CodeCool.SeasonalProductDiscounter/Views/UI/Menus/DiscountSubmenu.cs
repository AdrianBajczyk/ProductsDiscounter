using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;
using CodeCool.SeasonalProductDiscounter.Views.UI.Printer;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Menus;

public class DiscountSubmenu : AbstractMenu
{

    private readonly IDiscountProvider _discountProvider;
    

    public DiscountSubmenu(
        string title,
        bool needsAutification,
        IDiscountProvider discountProvider)
        :
        base(title, needsAutification)
    {
        _discountProvider = discountProvider;
    }

    public override void Display()
    {
        foreach (var log in _loggers)
        {
            log.Value.LogInfo(Title);
        }
        Run();
    }

    public void Run()
    {
        _uIPrinter.PrintDiscounts(_discountProvider.Discounts);
        _uIGetter.GetKeyToContinue();
    }
}