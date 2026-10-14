using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prakt6_Leshukov.Models;
using prakt6_Leshukov.Services;

namespace prakt6_Leshukov.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class EventsController :ControllerBase
    {
        private EventService service = new EventService( );
        [HttpGet]
        public IActionResult GetAll ([FromQuery] string? location, [FromQuery] bool? isActive)
        {
            return Ok(service.GetAll(location, isActive));
        }
        [HttpGet("{id:int}")]
        public IActionResult Get (int id)
        {
            
            var eventFind = service.Get(id);
            if(eventFind != null)
            {
                return Ok(eventFind);
            }
            else
            {
                return NoContent();
            }
           
        }
        [HttpPost]
        public IActionResult Create (Event ev)
        {
            if(ev != null)
            {
                if (!service.Create(ev))
                {
                    return BadRequest();
                }

                return Created();
            }
            else
                return NoContent();
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
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (service.Delete(id))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
