using Application.UseCases;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventParticipantsManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly EventUseCases _eventUseCases;

        public EventsController(EventUseCases eventUseCases)
        {
            _eventUseCases = eventUseCases;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
        {
            var events = await _eventUseCases.GetAllEventsAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEventById(int id)
        {
            var event = await _eventUseCases.GetEventByIdAsync(id);
            if (event == null)
            {
            return NotFound();
        }
            return Ok(event);
        }

        [HttpGet("title/{title}")]
        public async Task<ActionResult<Event>> GetEventByTitle(string title)
        {
            var event = await _eventUseCases.GetEventByTitleAsync(title);
            if (event == null)
            {
            return NotFound();
        }
            return Ok(event);
        }

        [HttpGet("criteria")]
        public async Task<ActionResult<IEnumerable<Event>>> GetEventsByCriteria(DateTime? date, string location, string category)
        {
            var events = await _eventUseCases.GetEventsByCriteriaAsync(date, location, category);
            return Ok(events);
        }

        [HttpPost]
        public async Task<ActionResult> AddEvent(Event event)
        {
            await _eventUseCases.AddEventAsync(event);
            return CreatedAtAction(nameof(GetEventById), new { id = event.Id }, event);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEvent(int id, Event event)
        {
            if (id != event.Id)
            {
            return BadRequest();
        }

        await _eventUseCases.UpdateEventAsync(event);
            return NoContent();
        }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEvent(int id)
    {
        await _eventUseCases.DeleteEventAsync(id);
        return NoContent();
    }
}
}