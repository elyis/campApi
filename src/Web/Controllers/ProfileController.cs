using System.Net;
using campapi.src.Domain.Entities.Response;
using campapi.src.Domain.IRepository;
using campApi.src.Domain.Entities.Request;
using campApi.src.Domain.Entities.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using webApiTemplate.src.App.IService;

namespace campapi.src.Web.Controllers
{
    [ApiController]
    [Route("campapi")]
    public class ProfileController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public ProfileController(
            IUserRepository userRepository,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }


        [HttpGet("profile"), Authorize]
        [SwaggerOperation("Получить профиль")]
        [SwaggerResponse(200, Description = "Успешно", Type = typeof(ProfileBody))]
        public async Task<IActionResult> GetProfileAsync(
            [FromHeader(Name = nameof(HttpRequestHeader.Authorization))] string token
        )
        {
            var tokenInfo = _jwtService.GetTokenInfo(token);
            var user = await _userRepository.GetAsync(tokenInfo.UserId);
            return user == null ? NotFound() : Ok(user.ToProfileBody());
        }

        [HttpGet("profile/docs"), Authorize]
        [SwaggerOperation("Получить документы")]
        [SwaggerResponse(200, Description = "Успешно", Type = typeof(UserDocumentsBody))]
        public async Task<IActionResult> GetProfileDocsAsync(
            [FromHeader(Name = nameof(HttpRequestHeader.Authorization))] string token
        )
        {
            var tokenInfo = _jwtService.GetTokenInfo(token);
            var user = await _userRepository.GetAsync(tokenInfo.UserId);
            return user == null ? NotFound() : Ok(user.ToUserDocumentsBody());
        }

        [HttpPut("profile"), Authorize]
        [SwaggerOperation("Обновить профиль")]
        [SwaggerResponse(200, Description = "Успешно", Type = typeof(ProfileBody))]
        public async Task<IActionResult> UpdateProfileAsync(
            [FromHeader(Name = nameof(HttpRequestHeader.Authorization))] string token,
            UpdatedProfileInfo profileInfo
        )
        {
            var tokenInfo = _jwtService.GetTokenInfo(token);
            var user = await _userRepository.UpdateProfileInfo(tokenInfo.UserId, profileInfo);
            return user == null ? NotFound() : Ok(user.ToProfileBody());
        }
    }
}