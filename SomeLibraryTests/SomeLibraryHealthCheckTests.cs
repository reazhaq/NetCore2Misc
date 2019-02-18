using System;
using System.Linq;
using System.Threading;
using SomeLibrary;
using Xunit;
using Xunit.Abstractions;

namespace SomeLibraryTests
{
    public class SomeLibraryHealthCheckTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public SomeLibraryHealthCheckTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void HealthCheckAsyncTest()
        {
            var someLibraryHealthCheck = new SomeLibraryHealthCheck(null);

            foreach (var i in Enumerable.Range(1,10))
            {
                var healthResult = someLibraryHealthCheck.CheckHealthAsync(null).Result;
                _testOutputHelper.WriteLine($"healthResult - Status:{healthResult.Status}, Desc:{healthResult.Description}");
                Thread.Sleep(100);
            }
        }
    }
}
