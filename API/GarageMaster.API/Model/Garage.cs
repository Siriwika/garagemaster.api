using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMaster.API.Model
{
    public class Garage
    {
		public int G_Id { get; set; }
		public string G_Image { get; set; }
		public string G_Name { get; set; }
		public string G_Description { get; set; }
		public string G_Phone { get; set; }
		public string G_Date { get; set; }
		public string openTime { get; set; }
		public TimeSpan G_Open_Time { get; set; }
		public string closeTime { get; set; }
		public TimeSpan G_Close_Time { get; set; }

		[Column(TypeName = "decimal(18,7)")]
		public decimal G_Latitude { get; set; }

		[Column(TypeName = "decimal(18,7)")]
		public decimal G_Longitude { get; set; }
		public int G_charge { get; set; }
		public string G_Service_Type { get; set; }
		public int UId { get; set; }
		public int SId { get; set; }
		public IFormFile FileImage { get; set; }
	}
}
