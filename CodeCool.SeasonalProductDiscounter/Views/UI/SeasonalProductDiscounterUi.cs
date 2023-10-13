using System.Collections;
using CodeCool.SeasonalProductDiscounter.Model.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Statistics;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus.CatalogSubmenu;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus.DiscountSubmenu;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus.OffersSubmenu;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus.StatisticsSubmenu;
using ConsoleTables;

namespace CodeCool.SeasonalProductDiscounter.Views.UI;

public class SeasonalProductDiscounterUi 
{
    private readonly ICatalogSubmenu _catalogSubmenu;
    private readonly IOffersSubmenu _offersSubmenu;
    private readonly IStatisticsSubmenu _statisticsSubmenu;
    private readonly IDiscountSubmenu _discountSubmenu;
    private readonly ILogger _logger;
    private readonly IUIGetter _uIGetter;



    public SeasonalProductDiscounterUi(
        ICatalogSubmenu catalogSubmenu,
        IOffersSubmenu offersSubmenu,
        IStatisticsSubmenu statisticsSubmenu,
        IDiscountSubmenu discountSubmenu,
        ILogger logger,
        IUIGetter uIGetter
        )
    {
        _catalogSubmenu = catalogSubmenu;
        _offersSubmenu = offersSubmenu;
        _statisticsSubmenu = statisticsSubmenu;
        _discountSubmenu = discountSubmenu;
        _logger = logger;
        _uIGetter = uIGetter;
    }

    public void Run()
    {
        _logger.LogInfo("Welcome to Seasonal Product Discounter!");
        _logger.NewLine();

        int select = 0;

        while (select != 5)
        {

            DisplayMenu();
            select = _uIGetter.GetIntFromUser();

            switch (select)
            {
                case 1:
                    _logger.Clear();
                    _catalogSubmenu.Run();
                    break;
                case 2:
                    _logger.Clear();
                    _discountSubmenu.Run();
                    _logger.Clear();
                    break;
                case 3:
                    _logger.Clear();
                    _offersSubmenu.Run();
                    break;
                case 4:
                    _logger.Clear();
                    _statisticsSubmenu.Run();
                    break;
                default:
                    _logger.Clear();
                    break;

            }
        }


    }
    private void DisplayMenu()
    {
        _logger.LogInfo("-----------Main Menu-----------");
        _logger.LogInfo("1. Catalog");
        _logger.LogInfo("2. Discounts");
        _logger.LogInfo("3. Offers for specified date");
        _logger.LogInfo("4. Products statistics");
        _logger.LogInfo("5. Exit");
        _logger.LogInfo("-------------------------------");
    }

}
