using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using JeffFerguson.SecQDb;

namespace SecQDbTest
{
    public class QuarterlyDatabaseTests
    {
        [Fact]
        public void ValidQuarterlyDatabase()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                Assert.True(qdb.Load("2015q4"));
            }
        }

        [Fact]
        public void InvalidQuarterlyDatabase()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                Assert.False(qdb.Load("2015q5"));
            }
        }
    }
}
