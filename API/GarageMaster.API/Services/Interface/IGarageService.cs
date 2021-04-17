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
        List<Service> GetServicebyTCId(int tcid);
        List<Service_of_Garage> GetServicebyGarage(int gid);
        List<Service_of_Garage> GetGaragebyService(int sid);
        string InsertGarage(Garage garage);
        string UpdateGarage(Garage garage);
        string DeleteGarage(int gid);
    }
}
