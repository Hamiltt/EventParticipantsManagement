using Domain.Interfaces;
using Domain.Models;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class EventUseCases
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventUseCases(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await _unitOfWork.Events.GetAllAsync();
        }

        public async Task<Event> GetEventByIdAsync(int id)
        {
            return await _unitOfWork.Events.GetByIdAsync(id);
        }

        public async Task<Event> GetEventByTitleAsync(string title)
        {
            return await _unitOfWork.Events.GetByTitleAsync(title);
        }

        public async Task<IEnumerable<Event>> GetEventsByCriteriaAsync(DateTime? date, string location, string category)
        {
            return await _unitOfWork.Events.GetByCriteriaAsync(date, location, category);
        }

        public async Task AddEventAsync(Event event)
        {
            await _unitOfWork.Events.AddAsync(event);
        await _unitOfWork.CompleteAsync();
        }

    public async Task UpdateEventAsync(Event event)
    {
        await _unitOfWork.Events.UpdateAsync(event);
        await _unitOfWork.CompleteAsync();
    }

    public async Task DeleteEventAsync(int id)
    {
        await _unitOfWork.Events.DeleteAsync(id);
        await _unitOfWork.CompleteAsync();
    }
}
}