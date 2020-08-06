using System.Collections.Generic;

namespace Lumity.Api.Models
{
    public class Question : BaseModel
    {
        public int QuizId { get; set; }
        public int Order { get; set; }
        public string Text { get; set; }
        public List<Option> Options { get; set; }
    }
}