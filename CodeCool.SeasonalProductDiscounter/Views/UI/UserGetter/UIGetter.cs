using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Getter;

public class UIGetter : IUIGetter
{
    private ILogger _logger;

    public UIGetter(ILogger logger)
    {
        _logger = logger;
    }
    public Color GetColorFromUser()
    {
        _logger.LogInfo("Enter a color:");

        string? input = null;
        Color color;

        while (!Enum.TryParse(input, out color))
        {
            if (input != null)
            {
                _logger.LogError("Color not found in the database. Try:");

                var colors = Enum.GetValues(typeof(Color));

                foreach (var item in colors)
                {
                    _logger.LogInfo(item.ToString());
                }

            }

            input = Console.ReadLine();
        }

        return color;
    }

    public DateTime GetDateFromUser()
    {
        _logger.LogInfo("Enter a date:");

        string? input = null;
        DateTime date;

        while (!DateTime.TryParse(input, out date))
        {
            if (input != null)
            {
                _logger.LogError("Invalid date!");
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
                _logger.LogError("Enter valid character");
                continue;
            }
            if (!int.TryParse(buffer, out var value))
            {
                _logger.LogError("Enter characters indicates integer input");
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
                _logger.LogError("Enter valid character");
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
                _logger.LogError("Enter valid character");
                continue;
            }
            if (!double.TryParse(buffer, out var value))
            {
                _logger.LogError("Enter characters indicates double input (0.00)");
                continue;
            }
            return Math.Round(value, 2);
        }
    }

    public PriceRange GetPriceRangeFromUser()
    {


        _logger.LogInfo("Enter minimum price range");

        var minimum = GetPriceFromUser();

        _logger.LogInfo("Enter maximum price range");

        var maximum = GetPriceFromUser();

        return new PriceRange(minimum, maximum);
        
    }

    public void GetKeyToContinue()
    {
        _logger.LogInfo("Press any key to continue");
        Console.ReadKey(true);
    }
}

