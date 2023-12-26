namespace campApi.src.Domain.Entities.Response
{
    public class QuestionWithAnswersBody
    {
        public string Description { get; set;}
        public int RightAnswerIndex { get; set; }
        public List<string> Answers { get; set; } = new();
    }
}