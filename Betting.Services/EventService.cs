using Betting.Common.InputModels;
using Betting.Data;
using Betting.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Betting.Services
{
    public class EventService
    {
        private readonly BettingDbContext dbContext;

        public EventService(BettingDbContext db)
        {
            this.dbContext = db;
        }

        public List<Event> GetEvents()
        {
            var e = dbContext.Events.Where(e => !e.IsDeleted).ToList();

            return e;
        }

        public List<EventType> GetEventTypes()
        {
            var et = dbContext.EventTypes.ToList();

            return et;
        }
        
        public bool DeleteEvent(int eventId)
        {
            var eventToRemove = dbContext.Events.FirstOrDefault(e => e.EventId == eventId);

            if (eventToRemove != null)
            {
                eventToRemove.IsDeleted = true;
                eventToRemove.Modified = DateTime.UtcNow;

                var rowsAffected = dbContext.SaveChanges();

                return rowsAffected > 0;
            }

            return false;
        }

        public bool EditEvent(EventModel eventModel)
        {
            var eventToEdit = dbContext.Events.FirstOrDefault(e => e.EventId == eventModel.EventId);

            if (eventToEdit != null)
            {
                eventToEdit.EventName = eventModel.EventName;
                eventToEdit.EventStartDate = eventModel.EventStartDate;
                eventToEdit.OddsForFirstTeam = eventModel.OddsForFirstTeam;
                eventToEdit.OddsForDraw = eventModel.OddsForDraw;
                eventToEdit.OddsForSecondTeam = eventModel.OddsForSecondTeam;
                eventToEdit.Modified = DateTime.UtcNow;

                var rowsAffected = dbContext.SaveChanges();

                return rowsAffected > 0;
            }

            return false;
        }
    }
}
