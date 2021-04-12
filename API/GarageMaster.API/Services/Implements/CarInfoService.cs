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
    public class CarInfoService : ICarInfoService
    {
        private readonly IBaseRepository _db;
        public CarInfoService(IBaseRepository baseRepository)
        {
            this._db = baseRepository;
        }

        public List<Car_Info> GetCarInfo(int cid)
        {
            string queryString = $@"SELECT * FROM Car_Info WHERE C_Id={cid}";
            var result = _db.QueryString<Car_Info>(queryString).ToList();
            return result;
        }

        public List<Car_Info> GetMyCar(int uid)
        {
            string queryString = $@"SELECT * FROM Car_Info WHERE UId={uid}";
            var result = _db.QueryString<Car_Info>(queryString).ToList();
            return result;
        }

        public string InsertCarInfo(Car_Info car_Info)
        {
            string queryString = $@"INSERT INTO Car_Info (C_Brand,C_Image,C_Engine,C_Battery,C_Coolant,C_Fuel,C_AirConditioning,C_PowerTrain,C_Braking,C_Tires,C_Steering,UId) VALUES
                                    ('{car_Info.C_Brand}'
                                    ,'{car_Info.C_Image}'
                                    ,'{car_Info.C_Engine}'
                                    ,'{car_Info.C_Battery}'
                                    ,'{car_Info.C_Coolant}'
                                    ,'{car_Info.C_Fuel}'
                                    ,'{car_Info.C_AirConditioning}'
                                    ,'{car_Info.C_PowerTrain}'
                                    ,'{car_Info.C_Braking}'
                                    ,'{car_Info.C_Tires}'
                                    ,'{car_Info.C_Steering}'
                                    ,{car_Info.UId})";
            var data = _db.ExecuteString<int>(queryString);

            if (data != 0)
            {
                return "CarInfoAdd Succes.";
            }
            else
            {
                return "CarInfoAdd failed.";
            }
        }

        public string UpdateCarinfo(Car_Info car_Info)
        {
            string queryString = $@"UPDATE Car_Info SET C_Brand='{car_Info.C_Brand}',
                                                        C_Image='{car_Info.C_Image}',
                                                        C_Engine='{car_Info.C_Engine}',
                                                        C_Battery='{car_Info.C_Battery}',
                                                        C_Coolant='{car_Info.C_Coolant}',
                                                        C_Fuel='{car_Info.C_Fuel}',
                                                        C_AirConditioning='{car_Info.C_AirConditioning}',
                                                        C_PowerTrain='{car_Info.C_PowerTrain}',
                                                        C_Braking='{car_Info.C_Braking}',
                                                        C_Tires='{car_Info.C_Tires}',
                                                        C_Steering='{car_Info.C_Steering}',
                                                        UId={car_Info.UId}
                                                        Where C_Id = {car_Info.C_Id}";
            var data = _db.ExecuteString<int>(queryString);
            if(data != 0)
            {
                return "Update Car Information success.";
            }
            else
            {
                return "Update CarInformation failed.";
            }
        }

        public string DeleteCarinfo(int cid)
        {
            string queryString = $@"DELETE FROM Car_Info where C_Id={cid}";
            var data = _db.ExecuteString<int>(queryString);
            if(data != 0)
            {
                return "Delete CarInformation Success.";
            }
            else
            {
                return "Delete CarInformation failed.";
            }
        }
    }

}
