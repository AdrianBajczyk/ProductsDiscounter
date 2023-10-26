using CodeCool.SeasonalProductDiscounter.Service.Statistics;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.MenuFactory;

public class StatisticsUIFactory : AbstractMenuFactory
{
    public override AbstractMenu CreateMenu()
    {
        return new StatisticsSubmenu("Statistics Submenu", false, new ProductStatistics());
    }
}
