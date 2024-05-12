using campApi.src.Domain.Entities.Response;
using campApi.src.Domain.Enums;

namespace campApi.src.Domain.Models
{
    public class QuestionModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Answers { get; set; }
        public int RightAnswerIndex { get; set; }

        public QuestionBody ToQuestionBody()
        {
            return new QuestionBody
            {
                Description = Description,
                RightAnswer = Answers.Split(";")[RightAnswerIndex]
            };
        }

        public QuestionWithAnswersBody ToQuestionWithAnswersBody()
        {
            var answers = Answers.Split(";").ToList();
            return new QuestionWithAnswersBody
            {
                Id = Id,
                Type = Enum.Parse<QuestionType>(Type),
                Description = Description,
                Answers = answers,
                RightAnswerIndex = RightAnswerIndex
            };
        }
    }
}