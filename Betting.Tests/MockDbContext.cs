using Betting.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Betting.Tests
{
    public class MockDbContext
    {
        public static BettingDbContext GetEmptyTestDb()
        {
            var options = new DbContextOptionsBuilder<BettingDbContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .EnableSensitiveDataLogging()
                            .Options;

            var db = new BettingDbContext(options);

            return db;
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            return connection;
        }
    }
}
