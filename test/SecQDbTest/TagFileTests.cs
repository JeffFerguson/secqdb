using JeffFerguson.SecQDb;
using Xunit;

namespace SecQDbTest
{
    /// <summary>
    /// IMPORTANT: All but one of unit tests will all fail until the data used by the
    /// tests is installed. See the "installing-test-data.txt" file in the "test/2015q4"
    /// folder for test data installation instructions.
    /// </summary>
    public class TagFileTests
    {
        [Fact]
        public void GetAllTagRecords()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                qdb.Load("2015q4");
                var allRecords = qdb.Tag.Records;
                Assert.Equal<int>(70602, allRecords.Count);
            }
        }
    }
}
