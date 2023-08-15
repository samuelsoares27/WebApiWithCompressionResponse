using Microsoft.AspNetCore.Mvc;

namespace WebApiWithCompressionResponse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Lorem ipsum dolor sit amet. Et assumenda quasi eos cumque dolores 33 sunt" +
                " tenetur eum illo eligendi. Et optio soluta in sint inventore quo galisum quidem" +
                " est velit sunt? Aut quasi saepe in consectetur quasi et saepe doloribus non quia" +
                " facilis ab quia quaerat et ipsam tempora.\r\n\r\nVel dolor excepturi qui nemo ullam" +
                " sit minima voluptatem sed error voluptatibus eum praesentium culpa qui iste cupiditate!" +
                " Nam quibusdam odio ut dolores odio et deserunt quia qui eius facere non maxime iure rem" +
                " fuga iste. Cum officia repudiandae et quia dolore ut rerum voluptatem non nobis atque ut" +
                " obcaecati repudiandae qui mollitia temporibus non voluptas eligendi? Et voluptas esse ea" +
                " voluptate earum et obcaecati sint qui veniam voluptas est officiis atque id impedit rerum." +
                "\r\n\r\n33 iste sunt eos sapiente rerum id aliquam quas hic laborum quibusdam aut tempore tenetur." +
                " Aut molestiae pariatur aut similique vitae sit adipisci voluptatum et explicabo voluptates. " +
                "Sed pariatur quisquam et velit cupiditate aut repellendus velit.";
        }
    }
}