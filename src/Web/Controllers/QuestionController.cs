using campapi.src.Infrastructure.Data;
using campApi.src.Domain.Entities.Request;
using campApi.src.Domain.Entities.Response;
using campApi.src.Domain.Enums;
using campApi.src.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace campApi.src.Web.Controllers
{
    [ApiController]
    [Route("campapi")]
    public class QuestionController : ControllerBase
    {
        private readonly AppDbContext _context;
        public QuestionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("question"), Authorize]
        [SwaggerOperation("Создать вопрос")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]

        public async Task<IActionResult> CreateQuestion(CreateQuestionBody body)
        {
            if (body.Answers.Count == 0)
                return BadRequest("no answers");

            if (body.Answers.Count > body.RightAnswerIndex && body.RightAnswerIndex >= 0)
            {
                var question = new QuestionModel
                {
                    Description = body.Description,
                    RightAnswerIndex = body.RightAnswerIndex,
                    Answers = string.Join(";", body.Answers),
                    Type = body.Type.ToString()
                };

                await _context.Questions.AddAsync(question);
                await _context.SaveChangesAsync();
                return Ok();
            }

            return BadRequest("Uncorrect right answer index");
        }

        [HttpGet("questions"), Authorize]
        [SwaggerOperation("Получить вопросы")]
        [SwaggerResponse(200, Type = typeof(IEnumerable<QuestionWithAnswersBody>))]
        public async Task<IActionResult> GetQuestions([FromQuery] QuestionType type)
        {
            var questionType = type.ToString();
            var questions = await _context.Questions.Where(e => e.Type == questionType).ToListAsync();
            return Ok(questions.Select(e => e.ToQuestionWithAnswersBody()));
        }
    }
}