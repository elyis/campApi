using campApi.src.Domain.Enums;

namespace campApi.src.Domain.Entities.Response
{
    public class QuestionWithAnswersBody
    {
        public Guid Id { get; set; }
        public QuestionType Type { get; set; }
        public string Description { get; set; }
        public int RightAnswerIndex { get; set; }
        public List<string> Answers { get; set; } = new();
    }
}