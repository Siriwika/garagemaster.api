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
    public class CarInfoController : ControllerBase
    {
        private readonly ICarInfoService carInfoService;
        private readonly string _url = "http://localhost:57047/images/";
        public CarInfoController(ICarInfoService carInfoService)
        {
            this.carInfoService = carInfoService;
        }

        [HttpGet("GetCar")]
        public IActionResult ShowDetailCar(int cid)
        {
            var result = carInfoService.GetCarInfo(cid);
            return new OkObjectResult(result);
        }

        [HttpGet("GetCarByUId")]
        public IActionResult ShowMyCar(int uid)
        {
            var result = carInfoService.GetMyCar(uid);
            return new OkObjectResult(result);
        }

        [HttpPost("AddCarInfo")]
        public IActionResult AddCarInfo([FromForm] Car_Info car_Info) 
        {
            try
            {
                string pathImage = Path.Combine(Directory.GetCurrentDirectory(),$@"wwwroot/images/{car_Info.FileImage.FileName}");
                using (var stream = new FileStream(pathImage,FileMode.Create))
                {
                    car_Info.FileImage.CopyTo(stream);
                }
                car_Info.C_Image = _url + car_Info.FileImage.FileName;
                var result = carInfoService.InsertCarInfo(car_Info);
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
