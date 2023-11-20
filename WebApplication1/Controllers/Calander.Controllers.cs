using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Calander : ControllerBase
    {
        private static int i=1;
        private static List<Event> events=new List<Event> { new Event { Id=i,Title="new task", Start =new DateTime(2023,11,01) }, new Event { Id = ++i, Title = "task2", Start = new DateTime(2023, 11, 07) }, new Event { Id = ++i, Title = "task3", Start = new DateTime(2023, 11, 10) } };
        
        
        // GET: api/<Calander>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return events;
        }

        // GET api/<Calander>/5
        [HttpGet("{id}")]
        public Event Get(int id)
        {
            return events.Find(x=>x.Id==id);
        }

        // POST api/<Calander>
        [HttpPost]
        public void Post([FromBody] Event value)
        {
            
            events.Add(new Event { Id=++i,Title=value.Title,Start=value.Start});
        }

        // PUT api/<Calander>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event value)
        {
            var eve = events.Find(x => x.Id == id);
            eve.Title=value.Title;
            eve.Start=value.Start;
          
        }

        // DELETE api/<Calander>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var delete = events.Find(x => x.Id == id);
            events.Remove(delete);
        }
    }
}
