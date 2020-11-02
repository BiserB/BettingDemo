﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Betting.Entities
{
    public class Event
    {
        public Event()
        {
            this.Modified = DateTime.UtcNow;
        }

        public int EventId { get; set; }

        public int EventTypeId { get; set; }
        [Required]
        public EventType EventType { get; set; }
        
        [Required]
        [MaxLength(256)]
        public string EventName { get; set; }

        [Range(1.00, double.MaxValue)]
        public double OddsForFirstTeam { get; set; }

        [Range(1.00, double.MaxValue)]
        public double? OddsForDraw { get; set; }

        [Range(1.00, double.MaxValue)]
        public double OddsForSecondTeam { get; set; }

        public DateTime EventStartDate { get; set; }

        [Required]
        public DateTime Modified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
