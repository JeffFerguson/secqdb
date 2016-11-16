using JeffFerguson.SecQDb;
using Xunit;

namespace SecQDbTest
{
    /// <summary>
    /// IMPORTANT: All but one of unit tests will all fail until the data used by the
    /// tests is installed. See the "installing-test-data.txt" file in the "test/2015q4"
    /// folder for test data installation instructions.
    /// </summary>
    public class PreFileTests
    {
        [Fact]
        public void GetAllPreRecords()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                qdb.Load("2015q4");
                var allRecords = qdb.Pre.Records;
                Assert.Equal<int>(885791, allRecords.Count);
            }
        }

        /// <summary>
        /// Every PRE record should have a matching SUB record. Their accession
        /// numbers should match.
        /// </summary>
        [Fact]
        public void GetMatchingSubRecordForFirstNumRecord()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                qdb.Load("2015q4");
                var firstPreRecord = qdb.Pre.Records[0];
                var matchingSubRecords = qdb.Sub.GetRecordsMatchingAccessionNumber(firstPreRecord.AccessionNumber);
                Assert.True(matchingSubRecords.Count == 1);
                var matchingSubRecord = matchingSubRecords[0];
                Assert.Equal<string>(firstPreRecord.AccessionNumber, matchingSubRecord.AccessionNumber);
            }
        }

        /// <summary>
        /// Every PRE record should have a matching TAG record. Their unique identifiers
        /// and versions should match.
        /// </summary>
        [Fact]
        public void GetMatchingTagRecordForFirstPreRecord()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                qdb.Load("2015q4");
                var firstPreRecord = qdb.Pre.Records[0];
                var matchingTagRecords = qdb.Tag.GetRecordsMatchingTagAndVersion(firstPreRecord.Tag, firstPreRecord.Version);
                Assert.True(matchingTagRecords.Count == 1);
                var matchingTagRecord = matchingTagRecords[0];
                Assert.Equal<string>(firstPreRecord.Tag, matchingTagRecord.Tag);
                Assert.Equal<string>(firstPreRecord.Version, matchingTagRecord.Version);
            }
        }

        [Fact]
        public void EnsureNoMatchingNumRecordForFirstPreRecord()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                qdb.Load("2015q4");
                var firstPreRecord = qdb.Pre.Records[0];
                var matchingNumRecords = qdb.Num.GetRecordsMatchingAccessionNumberTagAndVersion(firstPreRecord.AccessionNumber, firstPreRecord.Tag, firstPreRecord.Version);
                Assert.True(matchingNumRecords.Count == 0);
            }
        }

        /// <summary>
        /// Most PRE records will have a matching NUM record. Their accession numbers, tags
        /// and versions should match.
        /// </summary>
        /// <remarks>
        /// Not all records will have a match. This test specifically uses a record known to
        /// have at least one match.
        /// </remarks>
        [Fact]
        public void GetMatchingNumRecordForPreRecord()
        {
            using (var qdb = new QuarterlyDatabase())
            {
                qdb.Load("2015q4");
                var firstPreRecord = qdb.Pre.Records[9];
                var matchingNumRecords = qdb.Num.GetRecordsMatchingAccessionNumberTagAndVersion(firstPreRecord.AccessionNumber, firstPreRecord.Tag, firstPreRecord.Version);
                Assert.True(matchingNumRecords.Count > 0);
                foreach (var matchingNumRecord in matchingNumRecords)
                {
                    Assert.Equal<string>(firstPreRecord.AccessionNumber, matchingNumRecord.AccessionNumber);
                    Assert.Equal<string>(firstPreRecord.Tag, matchingNumRecord.Tag);
                    Assert.Equal<string>(firstPreRecord.Version, matchingNumRecord.Version);
                }
            }
        }
    }
}
