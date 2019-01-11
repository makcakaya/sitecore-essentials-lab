using Xunit;

namespace events.tac.local.Tests
{
    public sealed class Test1
    {
        [Fact]
        public void FailedTests()
        {
            Assert.True(false);
        }
    }
}