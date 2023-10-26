using CodeCool.SeasonalProductDiscounter.Model.Users;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;
using CodeCool.SeasonalProductDiscounter.Views.UI.Authentication;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;
using CodeCool.SeasonalProductDiscounter.Views.UI.MenuFactory;
using CodeCool.SeasonalProductDiscounter.Views.UI.Printer;

namespace CodeCool.SeasonalProductDiscounter.Views.UI;

public class UiSelector 
{
    private readonly IUserAutentificator _userAutentificator;
    private readonly SortedList<int, AbstractMenuFactory> _menusFactories;
    private readonly SortedList<string, ILogger> _loggers;
    private readonly IUIGetter _uIGetter;
    private readonly IUIPrinter _uIPrinter;

    private User? _user;




    public UiSelector(
        SortedList<string, ILogger> loggers,
        IUIGetter uIGetter,
        IUIPrinter uIPrinter,
        SortedList<int, AbstractMenuFactory> menusFactories,
        IUserAutentificator userAutentificator)
    {
        _userAutentificator = userAutentificator;
        _loggers = loggers;
        _uIGetter = uIGetter;
        _uIPrinter = uIPrinter;
        _menusFactories = menusFactories;
    }

    public void Select()
    {

        int select;
        int exit = _menusFactories.Count+1 ;


        while (true)
        {
            // jeżeli użytkownik poprosi o statystyki to wołasz faryke by stworzyła nową instancję statistic submenu i na niej wołasz metodę run

            _loggers["consoleLogger"].Clear();
            DisplayMenu();
            select = _uIGetter.GetIntFromUser();

            _loggers["consoleLogger"].Clear();

            if (select == exit) break;

            if (!_menusFactories.TryGetValue(select, out var submenu))
            {
                _loggers["consoleLogger"].LogError("Chosen option does not exist");
                _uIGetter.GetKeyToContinue();
                continue;
            }

            AuthentificateAndDisplaySubmenu(submenu);
        }


    }

    private void AuthentificateAndDisplaySubmenu(AbstractMenuFactory submenu)
    {
        var currentUI = submenu.CreateMenu();
        if (!currentUI.NeedsAutification) currentUI.Display();
        if (currentUI.NeedsAutification && _user == null) _user = _userAutentificator.LoginUser();
        if (_user != null) currentUI.Display();
    }


    private void DisplayMenu() //nie mam pomysłu jak zrobić to dynamicznie w obecnej sytuacji
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
