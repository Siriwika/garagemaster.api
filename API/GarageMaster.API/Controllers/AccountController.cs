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
        public IActionResult AddUser([FromBody] User user)
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
    }
}
