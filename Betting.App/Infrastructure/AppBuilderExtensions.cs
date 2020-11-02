using Betting.Data;
using Betting.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.App.Infrastructure
{
    public static class AppBuilderExtensions
    {
        private const string SeedFolder = @"Content";
        private const string FileExtension = @"txt";

        private static readonly string[] eventTypeNames =
        {
            "Football", "Basketball", "Horse-racing", "American football", "Tennis"
        };
        
        public static void InitialDbSeed(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<BettingDbContext>();

                dbContext.Database.Migrate();

                if (dbContext.EventTypes.Count() != eventTypeNames.Count())
                {
                    dbContext.Database.ExecuteSqlRaw("DELETE FROM Events");
                    dbContext.Database.ExecuteSqlRaw("DELETE FROM EventTypes");
                    dbContext.EventTypes.AddRange(eventTypeNames.Select(typeName => new EventType() { Name = typeName }));
                }
                
                dbContext.SaveChanges();

                foreach (var eventTypeName in eventTypeNames)
                {
                    var eventType = dbContext.EventTypes.FirstOrDefault(et => et.Name == eventTypeName);
                   
                    if (eventType == null)
                    {
                        continue;
                    }

                    var eventsInDb = dbContext.Events.Count(e => e.EventTypeId == eventType.Id);

                    if (eventsInDb > 0)
                    {
                        continue;
                    }

                    var events = CreateDemoEvents(eventTypeName, eventType);

                    if (events.Count > 0)
                    {
                        dbContext.Events.AddRange(events);

                        dbContext.SaveChanges();
                    }                    
                }
            }
        }

        private static List<Event> CreateDemoEvents(string eventTypeName, EventType eventType)
        {
            var directory = Path.GetFullPath(SeedFolder);

            var filename = $"{eventTypeName}.{FileExtension}";

            var fullPath = Path.Combine(directory, filename);

            var events = new List<Event>();

            if (File.Exists(fullPath))
            {
                var lines = File.ReadAllLines(fullPath);

                foreach (var line in lines)
                {
                    var splited = line.Split(",");

                    if (splited.Length != 5)
                    {
                        continue;
                    }

                    string name = splited[0].Trim();

                    double oddsFirst;
                    double? oddsDraw = null;
                    double oddsSecond;
                    DateTime date;

                    var oddsFirstIsValid = Double.TryParse(splited[1].Trim(), out oddsFirst);                    
                    var oddsSecondIsValid = Double.TryParse(splited[3].Trim(), out oddsSecond);
                    var dateIsValid = DateTime.TryParse(splited[4].Trim(), out date);

                    if (splited[2].Trim() != String.Empty)
                    {
                        double parseResult;
                        var oddsDrawIsValid = Double.TryParse(splited[2].Trim(), out parseResult);

                        if (oddsDrawIsValid)
                        {
                            oddsDraw = parseResult;
                        }
                    }

                    if (!oddsFirstIsValid || !oddsSecondIsValid || !dateIsValid)
                    {
                        continue;
                    }

                    events.Add(new Event()
                    {
                        EventTypeId = eventType.Id,
                        EventName = name,
                        OddsForFirstTeam = oddsFirst,
                        OddsForDraw = oddsDraw,
                        OddsForSecondTeam = oddsSecond,
                        EventStartDate = date
                    });
                }
            }

            return events;
        }
    }
}
