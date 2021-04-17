using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMaster.API.Model
{
    public class Service_of_Garage
    {
        public int SId { get; set; }
        public int G_Id { get; set; }
        public string G_Name { get; set; }
        public string G_Description { get; set; }
        public string G_Latitude { get; set; }
        public string G_Longitude { get; set; }

    }
}
