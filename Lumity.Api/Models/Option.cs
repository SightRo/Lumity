namespace Lumity.Api.Models
{
    public class Option : BaseModel
    {
        public int QuestionId { get; set; }
        public int Order { get; set; }
        public string Text { get; set; }
        public bool IsRight { get; set; }
    }
}