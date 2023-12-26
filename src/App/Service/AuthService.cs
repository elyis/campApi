using campapi.src.App.IService;
using campapi.src.Domain.Entities.Request;
using campapi.src.Domain.Entities.Shared;
using campapi.src.Domain.IRepository;
using Microsoft.AspNetCore.Mvc;
using webApiTemplate.src.App.IService;
using webApiTemplate.src.App.Provider;
using webApiTemplate.src.Domain.Entities.Shared;

namespace campapi.src.App.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public AuthService
        (
            IUserRepository userRepository,
            IJwtService jwtService
        )
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<IActionResult> SignIn(SignInBody body)
        {
            var user = await _userRepository.GetAsync(body.Email);
            if (user == null)
                return new NotFoundResult();

            var inputPasswordHash = Hmac512Provider.Compute(body.Password);
            if (user.Password != inputPasswordHash)
                return new BadRequestResult();

            var tokenInfo = new TokenInfo
            {
                Role = user.RoleName,
                UserId = user.Id
            };

            var tokenPair = _jwtService.GenerateDefaultTokenPair(tokenInfo);
            return new OkObjectResult(tokenPair);
        }

        public async Task<IActionResult> SignUp(SignUpBody body, string rolename)
        {
            var user = await _userRepository.AddAsync(body, rolename);
            if (user == null)
                return new ConflictResult();

            var tokenInfo = new TokenInfo
            {
                Role = user.RoleName,
                UserId = user.Id
            };

            var tokenPair = _jwtService.GenerateDefaultTokenPair(tokenInfo);
            return new OkObjectResult(tokenPair);
        }
    }
}