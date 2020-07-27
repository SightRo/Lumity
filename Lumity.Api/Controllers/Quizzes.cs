using Microsoft.AspNetCore.Mvc;

namespace Lumity.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class Quizzes : ControllerBase
    {
        public string Index()
            => "Hello world!";
    }
}