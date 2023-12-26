using campapi.src.Domain.Entities.Request;
using Microsoft.AspNetCore.Mvc;

namespace campapi.src.App.IService
{
    public interface IAuthService
    {
        Task<IActionResult> SignUp(SignUpBody body, string rolename);
        Task<IActionResult> SignIn(SignInBody body);
    }
}