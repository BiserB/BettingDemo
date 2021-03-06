﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Betting.Entities
{
    public class EventType
    {
        public EventType()
        {
            this.Events = new List<Event>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Event> Events { get; set; }
    }
}
