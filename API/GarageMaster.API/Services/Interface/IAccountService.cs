using GarageMaster.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMaster.API.Services.Interface
{
    public interface IAccountService
    {
        string AddUser(User user);
    }
}
