using System;
using System.Threading.Tasks;
using tillsammans.Auth;

namespace tillsammans.Mocks
{
    public class AuthServiceMock : IAuthService
    {
        public async Task<SignInResponse> SignIn(SignInRequest request)
        {
            await Task.Run(() => { });

            return new SignInResponse()
            {
                Session = new SessionDto() { Expires = DateTime.Now.AddDays(100).Ticks, Token = "valid token", UserId = request.Name }
            };
        }

        public async Task<SignUpResponse> SignUp(SignUpRequest request)
        {
            await Task.Run(() => { });


            return new SignUpResponse()
            {
                Session = new SessionDto() { Expires = DateTime.Now.AddDays(100).Ticks, Token = "valid token", UserId = request.Name }
            };
        }
    }
}
