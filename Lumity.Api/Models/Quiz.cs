using System;
using System.Collections.Generic;

namespace Lumity.Api.Models
{
    public class Quiz : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Question> Questions { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}