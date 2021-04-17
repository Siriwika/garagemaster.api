using GarageMaster.API.Model;
using GarageMaster.API.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GarageController : ControllerBase
    {
        private readonly IGarageService garageService;
        private readonly string _url = "http://139.59.229.66:5002/images/";
        public GarageController(IGarageService garageService)
        {
            this.garageService = garageService;
        }

        [HttpGet("GetGarage")]
        public IActionResult ShowDetailGarage()
        {
            var result = garageService.GetAllGarage();
            return new OkObjectResult(result);
        }
        [HttpGet("GetService")]
        public IActionResult ServiceByTCId(int tcid)
        {
            var result = garageService.GetServicebyTCId(tcid);
            return new OkObjectResult(result);
        }

        [HttpGet("GetServicebyGarage")]
        public IActionResult ServiceByGarage(int gid)
        {
            var result = garageService.GetServicebyGarage(gid);
            return new OkObjectResult(result);
        }


        [HttpGet("GetGarageByService")]
        public IActionResult GarageByService(int sid)
        {
            var result = garageService.GetGaragebyService(sid);
            return new OkObjectResult(result);
        }

        [HttpPost("AddGarage")]
        public IActionResult AddGarage([FromForm] Garage garage)
        {
            try
            {
                garage.G_Open_Time = TimeSpan.Parse(garage.openTime);
                garage.G_Close_Time = TimeSpan.Parse(garage.closeTime);
                string pathImage = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot/images/{garage.FileImage.FileName}");
                using (var stream = new FileStream(pathImage, FileMode.Create))
                {
                    garage.FileImage.CopyTo(stream);
                }
                garage.G_Image = _url + garage.FileImage.FileName;
                var result = garageService.InsertGarage(garage);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception e)
            {
                return StatusCode
                    (StatusCodes.Status500InternalServerError, e.Message);
            }

        }

        [HttpPut("UpdateGarage")]
        public IActionResult UpdateGarage([FromForm] Garage garage)
        {
            try
            {
                garage.G_Open_Time = TimeSpan.Parse(garage.openTime);
                garage.G_Close_Time = TimeSpan.Parse(garage.closeTime);
                string pathImage = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot/images/{garage.FileImage.FileName}");
                using (var stream = new FileStream(pathImage, FileMode.Create))
                {
                    garage.FileImage.CopyTo(stream);
                }
                garage.G_Image = _url + garage.FileImage.FileName;
                var result = garageService.UpdateGarage(garage);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception e)
            {
                return StatusCode
                    (StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromQuery] int gid)
        {
            try
            {
                var result = garageService.DeleteGarage(gid);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("help_check")]
        public Object HelpCheck()
        {
            try
            {
                return new { status = "200", message = "success" };
            }
            catch (Exception e)
            {
                return new { status = "500", message = e.Message };
            }

        }
    }
}
