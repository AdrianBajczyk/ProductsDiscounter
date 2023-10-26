using CodeCool.SeasonalProductDiscounter.Model.Users;
using CodeCool.SeasonalProductDiscounter.Service.Authentication;
using CodeCool.SeasonalProductDiscounter.Ui.Logger;
using CodeCool.SeasonalProductDiscounter.Views.UI.Getter;

namespace CodeCool.SeasonalProductDiscounter.Views.UI.Authentication;

public class UserAutentificator : IUserAutentificator
{
    private readonly IAuthenticationService _authenticator;
    private readonly IUIGetter _uIGetter;
    private readonly SortedList<string, ILogger> _loggers;

    public UserAutentificator(IAuthenticationService authenticator, IUIGetter uIGetter, SortedList<string, ILogger> loggers)
    {
        _authenticator = authenticator;
        _uIGetter = uIGetter;
        _loggers = loggers;
    }

    public User LoginUser()
    {
        string userName;
        string password;

        _loggers["consoleLogger"].LogInfo("To be able to see some content you need to be logged in. Do you want to log in now?");
        _loggers["consoleLogger"].LogInfo("Y/N");

        var answer = GetTrueOrFalse();

        while (answer)
        {
            _loggers["consoleLogger"].LogInfo("Enter user name than password");


            userName = _uIGetter.GetPhraseFromUser();
            password = _uIGetter.GetPhraseFromUser();

            var suppesedUser = new User(userName, password);

            if (_authenticator.Authenticate(suppesedUser))
            {
                foreach (var logger in _loggers)
                {
                    logger.Value.LogSuccess($"You have been logged as: {userName}");
                }
                _uIGetter.GetKeyToContinue();
                _loggers["consoleLogger"].Clear();
                return suppesedUser;
            }
            else
            {
                foreach (var logger in _loggers)
                {
                    logger.Value.LogError($"Login and password doesn't match: {userName}");
                }
                _loggers["consoleLogger"].LogInfo("Do you want to try again?");
                _loggers["consoleLogger"].LogInfo("Y/N");
                answer = GetTrueOrFalse();
            }
        }


        return null;
    }



    private bool GetTrueOrFalse() //zapytaj o przerośniętego UiGettera (czy dodać jeszcze to)
    {
        var answer = _uIGetter.GetPhraseFromUser();

        while (true)
        {
            if (string.IsNullOrWhiteSpace(answer))
            {
                _loggers["consoleLogger"].LogError("You enetered nothing or space only. Try again");
                continue;
            }
            if (answer.ToLower() == "y")
            {
                return true;
            }
            if (answer.ToLower() == "n")
            {
                return false;
            }
            else _loggers["consoleLogger"].LogError("Non valid answer. Type Y/N");

        }
    }

}
