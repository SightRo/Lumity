using System.Collections.Generic;
using Lumity.Api.Models;

namespace Lumity.Api.Data
{
    public class QuizStore
    {
        private readonly List<Quiz> _quizzes;

        public QuizStore()
        {
            _quizzes = new List<Quiz>();
        }

        public IEnumerable<Quiz> All
            => _quizzes;

        public void Add(Quiz quiz)
        {
            quiz.Id = _quizzes.Count;
            _quizzes.Add(quiz);
        }
    }
}