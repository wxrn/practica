using Microsoft.AspNetCore.Mvc;

namespace BackendApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{index}")]
        public List<string> Get()
        {
            return Summaries;
        }

        [HttpPost]

        public IActionResult Add(string name)
        {


            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!!!");
            }
            Summaries[index] = name;
            return Ok();
        }
        [HttpDelete]

        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!!!");
            }
            Summaries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]
        public IActionResult GetItem(int index)
        {
            if (index >= 0 && index < Summaries.Count)
            {
                return Ok(Summaries[index]);
            }
            else
            {
                return BadRequest("НЕПРАВИЛЬНО");
            }
        }
        [HttpGet("find-by-name")]
        public IActionResult GetItemCount(string name)
        {
            int count = Summaries.Count(Summaries => Summaries.Contains(name));
            return Ok(count);
        }
        [HttpGet("get-all")]
        public IActionResult GetAll(string strategy = null)
        {
            if (strategy == null)
            {
                return Ok(Summaries);
            }
            else if (strategy == "1")
            {
                return Ok(Summaries.OrderBy(item => item));
            }
            else if (strategy == "-1")
            {
                return Ok(Summaries.OrderByDescending(item => item));
            }
            else
            {
                return BadRequest("Некорректное значение параметра sortStrategy");
            }
        }
    }
}