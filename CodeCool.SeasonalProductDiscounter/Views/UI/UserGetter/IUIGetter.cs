using CodeCool.SeasonalProductDiscounter.Model.Enums;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Getter;

public interface IUIGetter
{
    DateTime GetDateFromUser();

    Color GetColorFromUser();

    string GetPhraseFromUser();

    int GetIntFromUser();
}

