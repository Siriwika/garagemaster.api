using GarageMaster.API.Model;
using GarageMaster.API.Repositories;
using GarageMaster.API.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace GarageMaster.API.Services.Implement
{
    public class AccountService : IAccountService
    {
        private readonly IBaseRepository _db;
        public AccountService(IBaseRepository baseRepository)
        {
            this._db = baseRepository;
        }

        public string AddUser(GUser user)
        {
            string queryString = $@"INSERT INTO GUser (UFullName,U_Email) VALUES
                                    ('{user.UFullName}','{user.U_Email}')";
            var data = _db.ExecuteString<int>(queryString);
            if(data != 0)
            {
                return "UserAdd Success.";
            }
            else
            {
                return "UserAdd failed";
            }
        }

        public List<GUser> Login(string email)
        {
            string queryString = $@"Select *  from GUser where U_Email='{email}'";
            var data = _db.QueryString<GUser>(queryString).ToList();
            return data;
        }
    }
}
