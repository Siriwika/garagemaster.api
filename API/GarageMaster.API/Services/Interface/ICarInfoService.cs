using GarageMaster.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMaster.API.Services.Interface
{
    public interface ICarInfoService
    {

        List<Car_Info> GetCarInfo(int cid);
        List<Car_Info> GetMyCar(int uid);
        string InsertCarInfo(Car_Info car_Info);
    }
}
