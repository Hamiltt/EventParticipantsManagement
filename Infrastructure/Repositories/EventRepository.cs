using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Event> GetByTitleAsync(string title)
        {
            return await _context.Events.FirstOrDefaultAsync(e => e.Title == title);
        }

        public async Task<IEnumerable<Event>> GetByCriteriaAsync(DateTime? date, string location, string category)
        {
            return await _context.Events
                .Where(e => (!date.HasValue || e.Date.Date == date.Value.Date)
                            && (string.IsNullOrEmpty(location) || e.Location == location)
                            && (string.IsNullOrEmpty(category) || e.Category == category))
                .ToListAsync();
        }
    }
}