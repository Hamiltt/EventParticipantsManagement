using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<Event> GetByTitleAsync(string title);
        Task<IEnumerable<Event>> GetByCriteriaAsync(DateTime? date, string location, string category);
    }
}