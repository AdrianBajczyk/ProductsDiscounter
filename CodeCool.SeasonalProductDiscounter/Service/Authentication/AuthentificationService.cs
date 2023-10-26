using CodeCool.SeasonalProductDiscounter.Model.Users;
using CodeCool.SeasonalProductDiscounter.Service.Authentication;

public class AuthentificationService : IAuthenticationService
{
    private List<User> _users { get; }

        public AuthentificationService()
    {
        _users = new List<User>()
        {
             new User("name1", "password1"),
             new User("name2", "password2"),
             new User("name3","password3")
        };
    }

    public bool Authenticate(User user)
    {
        return _users.Any(u => user.Equals(u));
    }

    
}