using System;
using Xunit;
using EnrollmentSystem.Core;

namespace EnrollmentSystem.Tests
{
    public class AdministrativeLogsTests
    {
        [Fact]
        public void PushSystemLog_ShouldRetrieveLogsInLIFOOrder()
        {
            var logs = new AdministrativeLogs();
            var log1 = new Log { LogId = "L-001", ActionSummary = "First Action" };
            var log2 = new Log { LogId = "L-002", ActionSummary = "Second Action" };

            logs.PushSystemLog(log1);
            logs.PushSystemLog(log2);

            Assert.Equal(2, logs.GetLogCount());

            var lastLog = logs.ViewLatestLog();
            Assert.Equal("L-002", lastLog.LogId);
        }

        [Fact]
        public void PeekSystemLog_ShouldReturnLatestLog_WithoutRemovingIt()
        {
            var logs = new AdministrativeLogs();
            var log = new Log { LogId = "L-001", ActionSummary = "Action" };
            logs.PushSystemLog(log);

            var peeked = logs.ViewLatestLog();

            Assert.Equal("L-001", peeked.LogId);
            Assert.Equal(1, logs.GetLogCount());
        }

        [Fact]
        public void CheckLogsEmpty_ShouldReturnTrue_WhenNoLogsExist()
        {
            var logs = new AdministrativeLogs();

            Assert.True(logs.CheckLogsEmpty());
        }

        [Fact]
        public void PopSystemLog_ShouldRemoveAndReturnLatestLog()
        {
            var logs = new AdministrativeLogs();
            var first = new Log { LogId = "L-001", ActionSummary = "First" };
            var second = new Log { LogId = "L-002", ActionSummary = "Second" };
            logs.PushSystemLog(first);
            logs.PushSystemLog(second);

            var popped = logs.PopSystemLog();

            Assert.Equal("L-002", popped.LogId);
            Assert.Equal(1, logs.GetLogCount());
        }
    }
}
