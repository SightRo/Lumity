using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lumity.Api.Data;
using Lumity.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lumity.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class QuizzesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public QuizzesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Quiz>> GetAll()
            => await _context.Quizzes.
                Include(q => q.Questions).
                ThenInclude(q => q.Options).
                ToListAsync();
        

        [HttpGet("{id}")]
        public async Task<Quiz> GetById(int id)
            => await _context.Quizzes.
                Include(q => q.Questions).
                ThenInclude(q => q.Options).
                SingleOrDefaultAsync(q => q.Id == id);

        [HttpPost]
        public async Task<Quiz> Create([FromBody] Quiz quiz)
        {
            quiz.Created = DateTime.Now;
            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();
            return quiz;
        }

        [HttpPut]
        public async Task<Quiz?> Update([FromBody] Quiz quiz)
        {
            if (quiz.Id == 0)
                return null;

            quiz.LastModified = DateTime.Now;
            _context.Quizzes.Update(quiz);
            await _context.SaveChangesAsync();
            return quiz;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            => throw new NotImplementedException();
    }
}