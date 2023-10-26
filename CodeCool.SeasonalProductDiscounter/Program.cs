using CodeCool.SeasonalProductDiscounter.Service.Browsers;
using CodeCool.SeasonalProductDiscounter.Service.Discounts;
using CodeCool.SeasonalProductDiscounter.Service.Products;
using CodeCool.SeasonalProductDiscounter.Service.Statistics;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;
using CodeCool.SeasonalProductDiscounter.Views.UI;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;
using CodeCool.SeasonalProductDiscounter.Views.UI.Printer;
using CodeCool.SeasonalProductDiscounter.Service.Authentication;
using CodeCool.SeasonalProductDiscounter.Views.UI.MenuFactory;
using CodeCool.SeasonalProductDiscounter.Views.UI.Authentication;

namespace CodeCool.SeasonalProductDiscounter;

class Program
{
    static void Main(string[] args)
    {

        var loggers = new SortedList<string, ILogger> //zapytaj Dominika czy to nie jest złamanie Liskova jeśli UiSelector dziedziczyłby z AbstractMenu
        {
            { "consoleLogger", new ConsoleLogger()},
            { "fileLogger", new FileLogger()} 
        };

        IUIPrinter uIPrinter = new UIPrinter(loggers);
        IUIGetter uIGetter = new UIGetter(loggers);

        IAuthenticationService authenticationService = new AuthentificationService();
        IUserAutentificator userAutentificator = new UserAutentificator(authenticationService,uIGetter,loggers);

        var menusCreators = new SortedList<int, AbstractMenuFactory>
        {
            {1, new CatalogUIFactory() },
            {2, new DiscountUIFactory() },
            {3, new OffersUIFactory() },
            {4, new StatisticsUIFactory() },
        };

        UiSelector selector = new UiSelector(loggers, uIGetter, uIPrinter, menusCreators, userAutentificator);
        loggers["fileLogger"].LogInfo(DateTime.Now.ToString());
        selector.Select();

        ;
        
    }
    
}