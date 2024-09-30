using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class ParticipantUseCases
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParticipantUseCases(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task RegisterParticipantAsync(int eventId, int participantId)
        {
            var eventParticipant = new EventParticipant
            {
                EventId = eventId,
                ParticipantId = participantId,
                RegistrationDate = DateTime.UtcNow
            };

            await _unitOfWork.EventParticipants.AddAsync(eventParticipant);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<Participant>> GetParticipantsByEventIdAsync(int eventId)
        {
            return await _unitOfWork.Participants.GetByEventIdAsync(eventId);
        }

        public async Task<Participant> GetParticipantByIdAsync(int id)
        {
            return await _unitOfWork.Participants.GetByIdAsync(id);
        }

        public async Task CancelParticipantRegistrationAsync(int eventId, int participantId)
        {
            await _unitOfWork.EventParticipants.DeleteAsync(eventId, participantId);
            await _unitOfWork.CompleteAsync();
        }
    }
}