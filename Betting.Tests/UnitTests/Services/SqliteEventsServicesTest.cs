using Betting.Data;
using Betting.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Betting.Tests.UnitTests.Services
{
    public class SqliteEventsServicesTest : EventServiceTest
    {
        public SqliteEventsServicesTest(DbContextOptions<BettingDbContext> contextOptions) : base(
            new DbContextOptionsBuilder<BettingDbContext>()
                .UseSqlite("Filename=Test.db")
                .Options)
        {
        }

        public void Can_get_items()
        {
            using (var context = new BettingDbContext(ContextOptions))
            {
                var service = new EventService(context);

                var events = service.GetEvents();

                Assert.AreEqual(1, events.Count);
                Assert.AreEqual("Demo", events[0].EventName);
            }
        }
    }
}
