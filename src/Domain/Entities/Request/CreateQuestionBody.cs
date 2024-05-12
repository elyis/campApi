using System.ComponentModel.DataAnnotations;
using campApi.src.Domain.Enums;

namespace campApi.src.Domain.Entities.Request
{
    public class CreateQuestionBody
    {
        public string Description { get; set; }
        public QuestionType Type { get; set; }

        [Range(0, int.MaxValue)]
        public int RightAnswerIndex { get; set; } = 0;
        public List<string> Answers { get; set; } = new();
    }
}