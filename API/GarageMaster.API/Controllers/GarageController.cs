using GarageMaster.API.Model;
using GarageMaster.API.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        [HttpGet("GetGaragebyId")]
        public IActionResult GetGarageById([FromQuery] int uid)
        {
            var result = garageService.GetGarageById(uid);
            return new OkObjectResult(result);
        }

        [HttpGet("GetService")]
        public IActionResult ServiceByTCId([FromQuery] int tcid)
        {
            var result = garageService.GetServicebyTCId(tcid);
            return new OkObjectResult(result);
        }

        [HttpGet("GetServicebyGarage")]
        public IActionResult ServiceByGarage([FromQuery] int gid)
        {
            var result = garageService.GetServicebyGarage(gid);
            return new OkObjectResult(result);
        }


        [HttpGet("GetGarageByService")]
        public IActionResult GarageByService([FromQuery] int sid)
        {
            var result = garageService.GetGaragebyService(sid);
            return new OkObjectResult(result);
        }

        [HttpPost("AddGarage")]
        public IActionResult AddGarage([FromForm] Garage garage)
        {
            try
            {
                string pathImage = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot/images/{garage.FileImage.FileName}");
                using (var stream = new FileStream(pathImage, FileMode.Create))
                {
                    garage.FileImage.CopyTo(stream);
                }
                var tmp = JsonConvert.DeserializeObject<List<Service_of_Garage>>(garage.listTmp);
                garage.G_Image = _url + garage.FileImage.FileName;
                garage.Tmp = tmp;
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
                if(garage.FileImage != null)
                {
                    string pathImage = Path.Combine(Directory.GetCurrentDirectory(), $@"wwwroot/images/{garage.FileImage.FileName}");
                    using (var stream = new FileStream(pathImage, FileMode.Create))
                {
                    garage.FileImage.CopyTo(stream);
                }
                    garage.G_Image = _url + garage.FileImage.FileName;
                }
                
                //var tmp = JsonConvert.DeserializeObject<List<Service_of_Garage>>(garage.listTmp);
              
                //garage.Tmp = tmp;
                var result = garageService.UpdateGarage(garage);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception e)
            {
                return StatusCode
                    (StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        [HttpDelete("DeleteGarage")]
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
        

        [HttpDelete("DeleteService")]
        public IActionResult Deleteservice([FromQuery] int gid)
        {
            try
            {
                var result = garageService.DeleteService(gid);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("InsertService")]
        public IActionResult InsertService([FromBody] Garage garage)
        {
            try
            {
                var tmp = JsonConvert.DeserializeObject<List<Service_of_Garage>>(garage.listTmp);
                garage.Tmp = tmp;
                var result = garageService.InsertService(garage);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception e)
            {
                return StatusCode
                    (StatusCodes.Status500InternalServerError, e.Message);
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
