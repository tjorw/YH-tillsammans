using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using tillsammans.Storage;
using tillsammans.App;
using System.Collections.Generic;
using System;
using System.Linq;

namespace tillsammans.Auth
{
    public class SignInFunction
    {
        private readonly ITokenService tokenService;

        public SignInFunction(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [FunctionName(nameof(SignInFunction.SignIn))]
        public IActionResult SignIn(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "auth/signin/{name}")] HttpRequest req,
            [CosmosDB(
                databaseName: StorageConst.DB_NAME,
                collectionName: StorageConst.DB_PROFILES_COLLECTIONNAME,
                ConnectionStringSetting = StorageConst.DB_CONNECTIONSTRING,
                SqlQuery = "select * from profiles g where g.name={name}")] IEnumerable<Profile> profiles,
            string name,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var request = req.DeserializeObject<SignUpRequest>();
            var profile = profiles.FirstOrDefault();

            if (string.IsNullOrWhiteSpace(request.Name))
            {
                return new BadRequestObjectResult($"Denied");
            }

            if (request.Name != name)
            {
                return new BadRequestObjectResult($"Denied");
            }

            if (profile == null)
            {
                return new BadRequestObjectResult($"Denied");
            }

            if(!grantAuth(request, profile))
            {
                return new BadRequestObjectResult($"Denied");
            }

            string responseMessage = createResponse(profile, tokenService);

            return new OkObjectResult(responseMessage);
        }

        private bool grantAuth(SignUpRequest request, Profile profile)
        {
            var key = Environment.GetEnvironmentVariable(ApiConst.AUTH_PASSWORDTOKENKEY);
            return tokenService.ValidateToken(profile.passwordToken, request.Password, key, profile.salt);
        }

        private string createResponse(Profile profile, ITokenService tokenService)
        {
            var key = Environment.GetEnvironmentVariable(ApiConst.AUTH_SESSIONTOKENKEY);
            var response = new SignInResponse()
            {
                Session = new SessionDto()
                {
                    UserId = profile.id,
                    Expires = DateTime.Now.AddDays(365).Ticks
                }
            };
            response.Session.Token = tokenService.CreateToken(response.Session, key);
            string responseMessage = JsonConvert.SerializeObject(response);
            return responseMessage;
        }
    }
}
