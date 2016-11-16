using JeffFerguson.SecQDb;
using Xunit;

namespace SecQDbTest
{
    /// <summary>
    /// IMPORTANT: All but one of unit tests will all fail until the data used by the
    /// tests is installed. See the "installing-test-data.txt" file in the "test/2015q4"
    /// folder for test data installation instructions.
    /// </summary>
    public class NumFileTests
    {
        [Fact]
        public void GetAllNumRecords()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                qdb.Load("2015q4");
                var allRecords = qdb.Num.Records;
                Assert.Equal<int>(1800907, allRecords.Count);
            }
        }

        /// <summary>
        /// Every NUM record should have a matching SUB record. Their accession
        /// numbers should match.
        /// </summary>
        [Fact]
        public void GetMatchingSubRecordForFirstNumRecord()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                qdb.Load("2015q4");
                var firstNumRecord = qdb.Num.Records[0];
                var matchingSubRecords = qdb.Sub.GetRecordsMatchingAccessionNumber(firstNumRecord.AccessionNumber);
                Assert.True(matchingSubRecords.Count == 1);
                var matchingSubRecord = matchingSubRecords[0];
                Assert.Equal<string>(firstNumRecord.AccessionNumber, matchingSubRecord.AccessionNumber);
            }
        }

        /// <summary>
        /// Every NUM record should have a matching TAG record. Their unique identifiers
        /// and versions should match.
        /// </summary>
        [Fact]
        public void GetMatchingTagRecordForFirstNumRecord()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                qdb.Load("2015q4");
                var firstNumRecord = qdb.Num.Records[0];
                var matchingTagRecords = qdb.Tag.GetRecordsMatchingTagAndVersion(firstNumRecord.Tag, firstNumRecord.Version);
                Assert.True(matchingTagRecords.Count == 1);
                var matchingTagRecord = matchingTagRecords[0];
                Assert.Equal<string>(firstNumRecord.Tag, matchingTagRecord.Tag);
                Assert.Equal<string>(firstNumRecord.Version, matchingTagRecord.Version);
            }
        }
    }
}
