using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Array.Core.Models;
using Array.Core.Services;
using Microsoft.Extensions.Options;

namespace Array.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JwtController : ControllerBase
    {
        private readonly ILogger<JwtController> _logger;
        IUserValidationService _uservalidationService;
        private readonly AppSettings _appSettings;
        public JwtController(ILogger<JwtController> logger, IUserValidationService uservalidationService, IOptions<AppSettings> options)
        {
            _logger = logger;
            _uservalidationService = uservalidationService;
            _appSettings = options.Value;
            var testVal = _appSettings.SecretKey;
        }
        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult Authenticate([FromBody]UserEntity model)
        {
            var user = this._uservalidationService.IsValidate(model.Username, model.Password);
            if (user == null)
            {
                return BadRequest(new { message = "UserName or Password is invalid" });
            }
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserEntity model)
        {
            try
            {
                var user = this._uservalidationService.IsValidate(model.Username, model.Password);
                if (user != null)
                {
                    return BadRequest(new { message = "Email Already Exist", status = 1 });
                }
                /*
                 other checks would include valid password requirement, valid email format
                 */
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
