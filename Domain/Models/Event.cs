using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public int MaxParticipants { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<EventParticipant> EventParticipants { get; set; }
    }
}