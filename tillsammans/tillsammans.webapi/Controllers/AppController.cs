using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using tillsammans.App;
using tillsammans.Auth;

namespace tillsammans.webapi.Controllers
{
    [ApiController]
    public class AppController : ControllerBase
    {
        private readonly IAppService appService;
        private readonly ITokenService tokenService;

        public AppController(IAppService appService, ITokenService tokenService)
        {
            this.appService = appService;
            this.tokenService = tokenService;
        }

    }
}
