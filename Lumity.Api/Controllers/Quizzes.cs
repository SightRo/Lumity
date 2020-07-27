using System;
using System.Linq;
using Lumity.Api.Data;
using Lumity.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lumity.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class Quizzes : ControllerBase
    {
        private readonly QuizStore _quizStore;

        public Quizzes(QuizStore quizStore)
        {
            _quizStore = quizStore;
        }

        [HttpGet]
        public IActionResult GetAll()
            => Ok(_quizStore.All);

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
            => Ok(_quizStore.All.FirstOrDefault(q => q.Id == id));

        [HttpPost]
        public IActionResult Create([FromBody] Quiz quiz)
        {
            _quizStore.Add(quiz);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] Quiz quiz)
            => throw new NotImplementedException();

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => throw new NotImplementedException();
    }
}