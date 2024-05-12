using System.Net;
using campapi.src.Domain.IRepository;
using campApi.src.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeDetective;
using MimeTypes.Core;
using Swashbuckle.AspNetCore.Annotations;
using webApiTemplate.src.App.IService;

namespace campapi.src.Web.Controllers
{
    [ApiController]
    [Route("campapi/upload")]
    public class UploadController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IFileUploaderService _fileUploaderService;
        private readonly ContentInspector _contentInspector;
        private readonly string _supportedIconMime;


        public UploadController(
            IUserRepository userRepository,
            IJwtService jwtService,
            IFileUploaderService fileUploaderService,
            ContentInspector contentInspector
        )
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _fileUploaderService = fileUploaderService;
            _contentInspector = contentInspector;
            _supportedIconMime = "image/";
        }

        [HttpPost("profile"), Authorize]
        [SwaggerOperation("Загрузить иконку профиля")]
        [SwaggerResponse(200, Description = "Успешно", Type = typeof(string))]

        public async Task<IActionResult> UploadProfileIcon(
            [FromHeader(Name = nameof(HttpRequestHeader.Authorization))] string token
        )
        {
            var file = Request.Form.Files.FirstOrDefault();
            var resultUpload = await UploadIconAsync(Constants.localPathToProfileIcons, file, new[] { _supportedIconMime });

            if (resultUpload is OkObjectResult result)
            {
                var filename = (string)result.Value;
                var tokenInfo = _jwtService.GetTokenInfo(token);
                await _userRepository.UpdateProfileIconAsync(tokenInfo.UserId, filename);
            }
            return resultUpload;
        }

        [HttpPost("profile/docs"), Authorize]
        [SwaggerOperation("Загрузить документы")]
        [SwaggerResponse(200, Description = "Успешно", Type = typeof(string))]


        public async Task<IActionResult> UploadDocs(
            [FromHeader(Name = nameof(HttpRequestHeader.Authorization))] string token,
            [FromQuery] UserDocuments doc
        )
        {
            var file = Request.Form.Files.FirstOrDefault();
            var resultUpload = await UploadIconAsync(Constants.localPathToProfileIcons, file, new[] { _supportedIconMime, "application/pdf" });

            if (resultUpload is OkObjectResult result)
            {
                var filename = (string)result.Value;
                var tokenInfo = _jwtService.GetTokenInfo(token);
                await _userRepository.UpdateDocument(tokenInfo.UserId, doc, filename);
            }
            return resultUpload;
        }

        [HttpGet("profile/docs/{filename}")]
        [SwaggerOperation("Получить иконку профиля")]
        [SwaggerResponse(200, Description = "Успешно", Type = typeof(File))]
        [SwaggerResponse(404, Description = "Неверное имя файла")]

        public async Task<IActionResult> GetDocument(string filename)
            => await GetIconAsync(Constants.localPathToProfileIcons, filename);


        [HttpGet("profileIcon/{filename}")]
        [SwaggerOperation("Получить иконку профиля")]
        [SwaggerResponse(200, Description = "Успешно", Type = typeof(File))]
        [SwaggerResponse(404, Description = "Неверное имя файла")]

        public async Task<IActionResult> GetProfileIcon(string filename)
            => await GetIconAsync(Constants.localPathToProfileIcons, filename);




        private async Task<IActionResult> GetIconAsync(string path, string filename)
        {
            var bytes = await _fileUploaderService.GetStreamFileAsync(path, filename);
            if (bytes == null)
                return NotFound();

            var extension = Path.GetExtension(filename);
            var mimeType = MimeTypeMap.GetMimeType(extension);
            return File(bytes, mimeType, filename);
        }

        private async Task<IActionResult> UploadIconAsync(string path, IFormFile file, string[] supportedMimes)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded");

            var stream = file.OpenReadStream();
            var mimeTypes = _contentInspector.Inspect(stream).ByMimeType();
            var bestMatchMimeType = mimeTypes.MaxBy(e => e.Points)?.MimeType;
            if (bestMatchMimeType == null)
                return new UnsupportedMediaTypeResult();


            bool isSupportedType = false;
            foreach (var supportedMime in supportedMimes)
            {
                if (bestMatchMimeType.StartsWith(_supportedIconMime) || supportedMime == bestMatchMimeType)
                {
                    isSupportedType = true;
                    break;
                }
            }

            if (string.IsNullOrEmpty(bestMatchMimeType) || !isSupportedType)
                return new UnsupportedMediaTypeResult();

            var fileExtension = bestMatchMimeType.Split("/").Last();
            string? filename = await _fileUploaderService.UploadFileAsync(path, stream, $".{fileExtension}");
            if (filename == null)
                return BadRequest("Failed to upload the file");

            return Ok(filename);
        }
    }
}