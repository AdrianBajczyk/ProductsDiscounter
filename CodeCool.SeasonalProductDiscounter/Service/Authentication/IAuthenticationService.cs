using CodeCool.SeasonalProductDiscounter.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeCool.SeasonalProductDiscounter.Service.Authentication
{
    public interface IAuthenticationService
    {
       public bool Authenticate(User user);
    }
}
