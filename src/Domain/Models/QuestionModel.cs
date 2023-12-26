using campApi.src.Domain.Entities.Response;

namespace campApi.src.Domain.Models
{
    public class QuestionModel
    {
        public Guid Id { get; set; }
        public string Description { get; set;}
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
                Description = Description,
                Answers = answers,
                RightAnswerIndex = RightAnswerIndex
            };
        }
    }
}