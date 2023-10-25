using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Getter;

public class UIGetter : IUIGetter
{
    private ILogger _consoleLogger;

    public UIGetter(SortedList<string, ILogger> loggers)
    {
        _consoleLogger = loggers["consoleLogger"];
    }
    public Color GetColorFromUser()
    {
        _consoleLogger.LogInfo("Enter a color:");

        string? input = null;
        Color color;

        while (!Enum.TryParse(input, out color))
        {
            if (input != null)
            {
                _consoleLogger.LogError("Color not found in the database. Try:");

                var colors = Enum.GetValues(typeof(Color));

                foreach (var item in colors)
                {
                    _consoleLogger.LogInfo(item.ToString());
                }

            }

            input = Console.ReadLine();
        }

        return color;
    }

    public DateTime GetDateFromUser()
    {
        _consoleLogger.LogInfo("Enter a date:");

        string? input = null;
        DateTime date;

        while (!DateTime.TryParse(input, out date))
        {
            if (input != null)
            {
                _consoleLogger.LogError("Invalid date!");
            }

            input = Console.ReadLine();
        }

        return date;
    }

    public int GetIntFromUser()
    {
        string buffer;

        while (true)
        {
            buffer = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(buffer))
            {
                _consoleLogger.LogError("Enter valid character");
                continue;
            }
            if (!int.TryParse(buffer, out var value))
            {
                _consoleLogger.LogError("Enter characters indicates integer input");
                continue;
            }
            return value;
        }
    }

    public string GetPhraseFromUser()
    {
        string buffer;

        while (true)
        {
            buffer = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(buffer))
            {
                _consoleLogger.LogError("Enter valid character");
                continue;
            }

            return buffer;
        }
    }

    public double GetPriceFromUser()
    {


        string buffer;

        while (true)
        {
            buffer = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(buffer))
            {
                _consoleLogger.LogError("Enter valid character");
                continue;
            }
            if (!double.TryParse(buffer, out var value))
            {
                _consoleLogger.LogError("Enter characters indicates double input (0.00)");
                continue;
            }
            return Math.Round(value, 2);
        }
    }

    public PriceRange GetPriceRangeFromUser()
    {


        _consoleLogger.LogInfo("Enter minimum price range");

        var minimum = GetPriceFromUser();

        _consoleLogger.LogInfo("Enter maximum price range");

        var maximum = GetPriceFromUser();

        return new PriceRange(minimum, maximum);
        
    }

    public void GetKeyToContinue()
    {
        _consoleLogger.LogInfo("Press any key to continue");
        Console.ReadKey(true);
    }
}

