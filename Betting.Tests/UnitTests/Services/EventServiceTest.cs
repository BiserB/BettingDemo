using Betting.Data;
using Betting.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Tests.UnitTests.Services
{
    public class EventServiceTest
    {
        public EventServiceTest(DbContextOptions<BettingDbContext> contextOptions)
        {
            ContextOptions = contextOptions;

            Seed();
        }

        public DbContextOptions<BettingDbContext> ContextOptions { get; }

        private void Seed()
        {
            using (var context = new BettingDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var one = new Event()
                {
                    EventTypeId = 1,
                    EventName = "Demo",
                    OddsForFirstTeam = 1,
                    OddsForDraw = 2,
                    OddsForSecondTeam = 3,
                    EventStartDate = DateTime.UtcNow
                };                              

                context.Events.Add(one);

                context.SaveChanges();
            }
        }
    }
}
