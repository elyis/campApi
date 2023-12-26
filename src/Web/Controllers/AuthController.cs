using campapi.src.App.IService;
using campapi.src.Domain.Entities.Request;
using campapi.src.Domain.Entities.Shared;
using campapi.src.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace campapi.src.Web.Controllers
{
    [ApiController]
    [Route("campapi")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [SwaggerOperation("Регистрация")]
        [SwaggerResponse(200, "Успешно создан", Type = typeof(TokenPair))]
        [SwaggerResponse(400, "Токен не валиден или активирован")]
        [SwaggerResponse(409, "Почта уже существует")]


        [HttpPost("signup")]
        public async Task<IActionResult> SignUpAsync(SignUpBody signUpBody)
        {
            string role = Enum.GetName(signUpBody.Role)!;
            var result = await _authService.SignUp(signUpBody, role);
            return result;
        }



        [SwaggerOperation("Авторизация")]
        [SwaggerResponse(200, "Успешно", Type = typeof(TokenPair))]
        [SwaggerResponse(400, "Пароли не совпадают")]
        [SwaggerResponse(404, "Email не зарегистрирован")]

        [HttpPost("signin")]
        public async Task<IActionResult> SignInAsync(SignInBody signInBody)
        {
            var result = await _authService.SignIn(signInBody);
            return result;
        }

    }
}