using Dapper;
using GarageMaster.API.Model;
using GarageMaster.API.Repositories;
using GarageMaster.API.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMaster.API.Services.Implement
{
    public class GarageService : IGarageService
    {
        private readonly IBaseRepository _db;
        public GarageService(IBaseRepository baseRepository)
        {
            this._db = baseRepository;
        }
        public List<Garage> GetAllGarage()
        {
            string queryString = $@"SELECT * FROM GARAGE";
            var result = _db.QueryString<Garage>(queryString).ToList();
            return result;
        }

        public List<Service> GetServicebyTCId(int tcid)
        {
            string queryString = $@"SELECT SName FROM Service WHERE TC_Id = {tcid}";
            var result = _db.QueryString<Service>(queryString).ToList();
            return result;
        }

        public List<Service_of_Garage> GetGaragebyService(int sid)
        {

            string queryString = $@"SELECT Service_of_Garage.SId,Service_of_Garage.G_Id,Garage.G_Name,Garage.G_Latitude,Garage.G_Longitude 
                                        FROM Service_of_Garage INNER JOIN Service ON Service_of_Garage.SId = Service.SId	
                                        INNER JOIN Garage ON Service_of_Garage.G_Id = Garage.G_Id
                                        WHERE Service.SId = {sid}";
            var result = _db.QueryString<Service_of_Garage>(queryString).ToList();

            return result;
        }

        public string InsertGarage(Garage garage)
        {
            string queryString = $@"INSERT INTO GARAGE (G_Image,G_Name,G_Description,
                                    G_Phone,G_Date,G_Open_Time,G_Latitude,G_Longitude,
                                    G_charge,G_Service_Type,UId) VALUES
                                    ('{garage.G_Image}'
                                    ,'{garage.G_Name}'
                                    ,'{garage.G_Description}'
                                    ,'{garage.G_Phone}'
                                    ,'{garage.G_Date}'
                                    ,'{garage.G_Open_Time}'
                                    ,'{garage.G_Latitude}'
                                    ,'{garage.G_Longitude}'
                                    ,{garage.G_charge}
                                    ,'{garage.G_Service_Type}'
                                    ,{garage.UId})";
            var data = _db.ExecuteString<int>(queryString);

            string queryString2 = $@"SELECT G_Id FROM Garage WHERE G_Name='{garage.G_Name}'";
            var data1 = _db.ExecuteString<int>(queryString2);

            string queryString3 = $@"INSERT INTO Service_of_Garage (SId,G_Id) VALUES
                                        ({garage.SId},{data1})";
            //SId From UI
            var data2 = _db.ExecuteString<int>(queryString3);

            if (data != 0 && data2 != 0)
            {
                return "GarageAdd Succes.";
            }
            else
            {
                return "GarageAdd failed.";
            }
        }

        public string UpdateGarage(Garage garage)
        {
            string queryString = $@"UPDATE Garage SET G_Image = '{garage.G_Image}'
                                                    ,G_Name = '{garage.G_Name}'
                                                    ,G_Description = '{garage.G_Description}'
                                                    ,G_Phone = '{garage.G_Phone}'
                                                    ,G_Date = '{garage.G_Date}'
                                                    ,G_Open_Time = '{garage.G_Open_Time}'
                                                    ,G_Latitude = '{garage.G_Latitude}'
                                                    ,G_Longitude = '{garage.G_Longitude}'
                                                    ,G_charge = {garage.G_charge}
                                                    ,G_Service_Type = '{garage.G_Service_Type}'
                                                    ,UId = {garage.UId}
                                                    where G_Id = {garage.G_Id}";
            var data = _db.ExecuteString<int>(queryString);
            if (data != 0)
            {
                return "Update Garage Success.";
            }
            else
            {
                return "Update Garage failed.";
            }
        }
        public string DeleteGarage(int gid)
        {
            string queryString = $@"DELETE FROM Garage where G_Id={gid}";
            var data = _db.ExecuteString<int>(queryString);
            if (data != 0)
            {
                return "DeleteGarage Success.";
            }
            else
            {
                return "DeleteGarage failed. ";
            }
        }
    }
}
