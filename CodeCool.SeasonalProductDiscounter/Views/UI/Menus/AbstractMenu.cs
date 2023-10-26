using CodeCool.SeasonalProductDiscounter.Service.Products;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;
using CodeCool.SeasonalProductDiscounter.Views.UI.Printer;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Menus;

public abstract class AbstractMenu
{
    protected readonly SortedList<string, ILogger> _loggers;
    protected readonly IUIGetter _uIGetter;
    protected readonly IUIPrinter _uIPrinter;
    protected readonly IProductProvider _productProvider;
    

    public string Title { get; init; }
    public bool NeedsAutification { get; init; }

    protected AbstractMenu(string title, bool needsAutification)
    {
        _loggers = new SortedList<string, ILogger>
        {
            { "consoleLogger", new ConsoleLogger()},
            { "fileLogger", new FileLogger()}
        };
        _uIGetter = new UIGetter(_loggers);
        _uIPrinter = new UIPrinter(_loggers);
        _productProvider = new RandomProductGenerator();

        Title = title;
        NeedsAutification = needsAutification;
    }

    

    public abstract void Display();
}
