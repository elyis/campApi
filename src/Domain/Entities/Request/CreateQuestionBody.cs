namespace campApi.src.Domain.Entities.Request
{
    public class CreateQuestionBody
    {
        public string Description { get; set;}
        public int RightAnswerIndex { get; set; }
        public List<string> Answers { get; set; }
    }
}