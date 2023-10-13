using CodeCool.SeasonalProductDiscounter.Model.Enums;
using CodeCool.SeasonalProductDiscounter.Model.Products;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Getter;

public interface IUIGetter
{
    DateTime GetDateFromUser();

    Color GetColorFromUser();

    string GetPhraseFromUser();

    int GetIntFromUser();

    double GetPriceFromUser();

    PriceRange GetPriceRangeFromUser();

    void GetKeyToContinue();
}

