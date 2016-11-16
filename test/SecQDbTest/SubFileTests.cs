using JeffFerguson.SecQDb;
using System;
using Xunit;

namespace SecQDbTest
{
    /// <summary>
    /// IMPORTANT: All but one of unit tests will all fail until the data used by the
    /// tests is installed. See the "installing-test-data.txt" file in the "test/2015q4"
    /// folder for test data installation instructions.
    /// </summary>
    public class SubFileTests
    {
        [Fact]
        public void FindExactlyOneSubRecordForCik913290()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                qdb.Load("2015q4");
                var matchingRecords = qdb.Sub.GetRecordsMatchingCik("913290");
                Assert.Equal<int>(1, matchingRecords.Count);
            }
        }

        [Fact]
        public void CheckFilingStatusOnSubRecordForCik913290()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                qdb.Load("2015q4");
                var matchingRecords = qdb.Sub.GetRecordsMatchingCik("913290");
                var match = matchingRecords[0];
                Assert.Equal<SubRecord.FilerStatusValue>(SubRecord.FilerStatusValue.Accelerated, match.FilerStatus);
            }
        }

        [Fact]
        public void GetAllSubRecords()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                qdb.Load("2015q4");
                var allRecords = qdb.Sub.Records;
                Assert.Equal<int>(6928, allRecords.Count);
            }
        }

        [Fact]
        public void CheckXbrlInstanceUrlOnSubRecordForCik913290()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                qdb.Load("2015q4");
                var matchingRecords = qdb.Sub.GetRecordsMatchingCik("913290");
                var match = matchingRecords[0];
                Assert.Equal<string>("http://www.sec.gov/Archives/edgar/data/913290/000091329015000007/fro-20150630.xml", match.XbrlInstanceUrl);
            }
        }

        [Fact]
        public void CheckBalanceSheetDateOnSubRecordForCik913290()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                qdb.Load("2015q4");
                var matchingRecords = qdb.Sub.GetRecordsMatchingCik("913290");
                var match = matchingRecords[0];
                var expectedDate = new DateTime(2015, 6, 30);
                Assert.Equal<DateTime>(expectedDate, match.BalanceSheetDate);
            }
        }

        [Fact]
        public void CheckFilingDateOnSubRecordForCik913290()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                qdb.Load("2015q4");
                var matchingRecords = qdb.Sub.GetRecordsMatchingCik("913290");
                var match = matchingRecords[0];
                var expectedDate = new DateTime(2015, 10, 5);
                Assert.Equal<DateTime>(expectedDate, match.FilingDate);
            }
        }
    }
}
