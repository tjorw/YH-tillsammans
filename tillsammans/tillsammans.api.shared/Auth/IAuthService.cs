using System.Threading.Tasks;

namespace tillsammans.Auth
{
    public interface IAuthService
    {
        Task<SignUpResponse> SignUp(SignUpRequest request);
        Task<SignInResponse> SignIn(SignInRequest request);
    }
}
