using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMaster.API.Model
{
    public class Car_Info
    {
        public int C_Id { get; set; }
        public string C_Brand { get; set; }
        public string C_Image { get; set; }
        public  DateTime C_Engine { get; set; }
        public DateTime C_Battery { get; set; }
        public DateTime C_Coolant { get; set; }
        public DateTime C_Fuel { get; set; }
        public DateTime C_AirConditioning { get; set; }
        public DateTime C_PowerTrain { get; set; }
        public DateTime C_Braking { get; set; }
        public DateTime C_Tires { get; set; }
        public DateTime C_Steering { get; set; }
        public int UId { get; set; }
        public IFormFile FileImage { get; set; }

    }
}
