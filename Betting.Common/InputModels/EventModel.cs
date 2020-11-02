using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Betting.Common.InputModels
{
    public class EventModel
    {
        public int EventId { get; set; }

        public int EventTypeId { get; set; }

        [Required]
        [MaxLength(256)]
        public string EventName { get; set; }

        [Required]
        [Range(1.00, double.MaxValue)]
        public double OddsForFirstTeam { get; set; }

        [Range(1.00, double.MaxValue)]
        public double? OddsForDraw { get; set; }

        [Required]
        [Range(1.00, double.MaxValue)]
        public double OddsForSecondTeam { get; set; }

        public DateTime EventStartDate { get; set; }
    }
}
