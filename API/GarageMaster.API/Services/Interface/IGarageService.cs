using GarageMaster.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMaster.API.Services.Interface
{
    public interface IGarageService
    {
        List<Garage> GetAllGarage();
        List<Garage> GetGarageById(int uid);
        List<Service> GetServicebyTCId(int tcid);
        List<Service> GetServicebyGarage(int gid);
        List<Garage> GetGaragebyService(int sid);
        string InsertGarage(Garage garage);
        string InsertService(Garage garage);
        string UpdateGarage(Garage garage);
        string DeleteGarage(int gid);
        string DeleteService(int gid);
    }
}
