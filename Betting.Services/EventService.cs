using Betting.Data;
using Betting.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Services
{
    public class EventService
    {
        private readonly BettingDbContext db;

        public EventService(BettingDbContext db)
        {
            this.db = db;
        }

        public void GetEventsByType()
        {
            
        }
    }
}
