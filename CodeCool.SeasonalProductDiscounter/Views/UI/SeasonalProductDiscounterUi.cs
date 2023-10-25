using System.Collections;
using CodeCool.SeasonalProductDiscounter.Model.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Statistics;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus.CatalogSubmenu;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus.DiscountSubmenu;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus.OffersSubmenu;
using CodeCool.SeasonalProductDiscounter.Views.UI.Menus.StatisticsSubmenu;
using CodeCool.SeasonalProductDiscounter.Views.UI.Printer;
using ConsoleTables;

namespace CodeCool.SeasonalProductDiscounter.Views.UI;

public class SeasonalProductDiscounterUi 
{
    private readonly ICatalogSubmenu _catalogSubmenu;
    private readonly IOffersSubmenu _offersSubmenu;
    private readonly IStatisticsSubmenu _statisticsSubmenu;
    private readonly IDiscountSubmenu _discountSubmenu;
    private readonly SortedList<string, ILogger> _loggers;
    private readonly IUIGetter _uIGetter;
    private readonly IUIPrinter _uIPrinter;




    public SeasonalProductDiscounterUi(
        ICatalogSubmenu catalogSubmenu,
        IOffersSubmenu offersSubmenu,
        IStatisticsSubmenu statisticsSubmenu,
        IDiscountSubmenu discountSubmenu,
        SortedList<string,ILogger> loggers,
        IUIGetter uIGetter,
        IUIPrinter uIPrinter)
    {
        _catalogSubmenu = catalogSubmenu;
        _offersSubmenu = offersSubmenu;
        _statisticsSubmenu = statisticsSubmenu;
        _discountSubmenu = discountSubmenu;
        _loggers = loggers;
        _uIGetter = uIGetter;
        _uIPrinter = uIPrinter;
    }

    public void Run()
    {

        int select = 0;

        while (select != 5)
        {

            DisplayMenu();
            select = _uIGetter.GetIntFromUser();

            switch (select)
            {
                case 1:
                    _loggers["consoleLogger"].Clear();
                    _catalogSubmenu.Run();
                    break;
                case 2:
                    _loggers["consoleLogger"].Clear();
                    _discountSubmenu.Run();
                    _loggers["consoleLogger"].Clear();
                    break;
                case 3:
                    _loggers["consoleLogger"].Clear();
                    _offersSubmenu.Run();
                    break;
                case 4:
                    _loggers["consoleLogger"].Clear();
                    _statisticsSubmenu.Run();
                    break;
                default:
                    _loggers["consoleLogger"].Clear();
                    break;

            }
        }


    }
    private void DisplayMenu()
    {
        var menuContent = new List<string>();

        menuContent.Add("-----------Main Menu-----------");
        menuContent.Add("1. Catalog");
        menuContent.Add("2. Discounts");
        menuContent.Add("3. Offers for specified date");
        menuContent.Add("4. Products statistics");
        menuContent.Add("5. Exit");
        menuContent.Add("-------------------------------");

        _uIPrinter.PrintList(menuContent);
    }

}
