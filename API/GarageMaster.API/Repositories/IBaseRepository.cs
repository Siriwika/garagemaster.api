﻿using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMaster.API.Repositories
{
    public interface IBaseRepository
    {
        //Stored procedure
        IEnumerable<T> QueryStoreProcedure<T>(string spName, DynamicParameters dynamic);
        int ExecuteStoreProcedure<T>(string spName, DynamicParameters dynamic);

        //Query string
        IEnumerable<T> QueryString<T>(string sql);
        int ExecuteString<T>(string sql);
    }

}
