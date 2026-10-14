using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prakt6_Leshukov.Models;

namespace prakt6_Leshukov
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class EventsController :ControllerBase
    {
        private EventService service = new EventService( );
        [HttpGet]
        public IActionResult GetAll ()
        {
            return Ok(service.GetAll( ));
        }
        [HttpGet("{id:int}")]
        public IActionResult Get (int id)
        {
            var eventFind = service.Get(id);
            return Ok(eventFind);
        }
        [HttpPost]
        public IActionResult Create (Event ev)
        {
            service.Create(ev);
            return Ok( );
        }
        [HttpPut("{id:int}")]
        public IActionResult Change (int id, Event ev)
        {
            var result = service.Change(id, ev);
            return result == null ? NotFound( ) : Ok(result);
        }
        [HttpPatch("{id:int}")]
        public IActionResult ChangeSome (int id, EventPatch ev)
        {
            var result = service.ChangeSome(id,ev);
            return result == null ? NotFound( ) : Ok(result);
        }
    }
}
