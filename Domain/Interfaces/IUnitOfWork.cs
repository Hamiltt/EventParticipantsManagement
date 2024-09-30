using Domain.Models;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }
        IParticipantRepository Participants { get; }
        IRepository<EventParticipant> EventParticipants { get; }
        Task<int> CompleteAsync();
    }
}