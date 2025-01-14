﻿using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public ICollection<EventParticipant> EventParticipants { get; set; }
    }
}