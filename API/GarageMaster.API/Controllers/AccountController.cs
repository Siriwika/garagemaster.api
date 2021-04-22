using GarageMaster.API.Model;
using GarageMaster.API.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
    
        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        
        [HttpPost("AddUser")]
        public IActionResult AddUser([FromBody] GUser user)
        {
            try
            {
                var result = accountService.AddUser(user);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult LoginGUser([FromBody] string email)
        {

            try
            {
                var result = accountService.Login(email);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
    }
}
