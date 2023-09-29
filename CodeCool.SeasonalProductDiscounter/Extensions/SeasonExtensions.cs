using CodeCool.SeasonalProductDiscounter.Model.Enums;

namespace CodeCool.SeasonalProductDiscounter.Extensions;

public static class SeasonExtensions
{
    private static readonly Dictionary<Season, Month[]> SeasonsToMonths = new()
    {
        { Season.Spring, new[] { Month.March, Month.April, Month.May } },
        { Season.Summer, new[] { Month.June, Month.July, Month.August } },
        { Season.Autumn, new[] { Month.September, Month.October, Month.November } },
        { Season.Winter, new[] { Month.December, Month.January, Month.February } }
    };


    public static Season Shift(this Season season, int shift)
    {
        
        var enumMemberToValue = (int)season;
        var numberOfSeasons = SeasonsToMonths.Count;

        var shiftedValue = (enumMemberToValue + shift + numberOfSeasons) % numberOfSeasons;

        var convertedToEnum = (Season)shiftedValue;
        return convertedToEnum;
    }

    public static bool Contains(this Season season, DateTime date)
    {
        var monthsOfSeason = SeasonsToMonths[season];
        var monthFromDate = (Month)date.Month; 

        return monthsOfSeason.Contains(monthFromDate);
    }

    public static Season GetSeason(DateTime date)
    {
        foreach (var season in SeasonsToMonths.Keys)
        {
            if (Contains(season, date))
            {
                return season;
            }
        }


        throw new InvalidOperationException("Something went wrong while getting season in comparison to given date (check SeasonExtensions)");
    }
}
