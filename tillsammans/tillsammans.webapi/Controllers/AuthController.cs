using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tillsammans.App;
using tillsammans.Auth;

namespace tillsammans.webapi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpGet("Ping")]
        public string Ping()
        {
            return "PING";
        }


        [HttpPost("SignUp/{name}")]
        public Task<SignUpResponse> SignUp(SignUpRequest request, string name)
        {
            return authService.SignUp(request);
        }

        [HttpPost("SignIn/{name}")]
        public Task<SignInResponse> SignIn(SignInRequest request, string name)
        {
            return authService.SignIn(request);
        }
    }
}
