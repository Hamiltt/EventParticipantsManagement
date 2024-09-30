using Application.UseCases;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventParticipantsManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParticipantsController : ControllerBase
    {
        private readonly ParticipantUseCases _participantUseCases;

        public ParticipantsController(ParticipantUseCases participantUseCases)
        {
            _participantUseCases = participantUseCases;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterParticipant(int eventId, int participantId)
        {
            await _participantUseCases.RegisterParticipantAsync(eventId, participantId);
            return Ok();
        }

        [HttpGet("event/{eventId}")]
        public async Task<ActionResult<IEnumerable<Participant>>> GetParticipantsByEventId(int eventId)
        {
            var participants = await _participantUseCases.GetParticipantsByEventIdAsync(eventId);
            return Ok(participants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Participant>> GetParticipantById(int id)
        {
            var participant = await _participantUseCases.GetParticipantByIdAsync(id);
            if (participant == null)
            {
                return NotFound();
            }
            return Ok(participant);
        }

        [HttpDelete("cancel")]
        public async Task<ActionResult> CancelParticipantRegistration(int eventId, int participantId)
        {
            await _participantUseCases.CancelParticipantRegistrationAsync(eventId, participantId);
            return NoContent();
        }
    }
}
