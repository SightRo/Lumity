using System;
using System.Collections.Generic;
using System.IO;
using Lumity.Api.Models;

namespace Lumity.Api.Data
{
    public static class DataGenerator
    {
        public static List<Quiz> GenerateQuizzes(int quizCount, int questionCount = 3, int optionsCount = 4)
        {
            var quizzes = new List<Quiz>(quizCount);

            for (int i = 1; i <= quizCount; i++)
            {
                quizzes.Add(new Quiz
                {
                    Name = $"Quiz #{i}",
                    // Todo Find a better solution.
                    Description = Path.GetRandomFileName(),
                    Questions = GenerateQuestions(questionCount, optionsCount),
                    Created = DateTime.Now
                });
            }

            return quizzes;
        }
        
        public static List<Question> GenerateQuestions(int questionCount, int optionsCount = 4)
        {
            var questions = new List<Question>(questionCount);

            for (int i = 1; i <= questionCount; i++)
            {
                questions.Add(new Question
                {
                    Order = i,
                    Text = $"Question #{i}",
                    RightOption = new Random().Next(1, optionsCount),
                    Options = GenerateOptions(optionsCount)
                });
            }

            return questions;
        }

        public static List<Option> GenerateOptions(int optionsCount)
        {
            var options = new List<Option>(optionsCount);

            for (int i = 1; i <= optionsCount; i++)
            {
                options.Add(new Option
                {
                   Order = i,
                   Text = $"Options #{i}"
                });
            }

            return options;
        }
    }
}