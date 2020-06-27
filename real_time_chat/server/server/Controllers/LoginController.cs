using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Extensions;
using server.Resources;
using server.Domain.Services;

namespace server.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IIdentityService _iidentityService;
        public LoginController(IIdentityService iidentityService)
        {
            _iidentityService = iidentityService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody]UserCredentialResource userCredentialResource)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }


            var response = await _iidentityService.CreateAccessTokenAsync(userCredentialResource.Mail, userCredentialResource.Password);

            return View();
        }
    }
}