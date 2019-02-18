using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SomeLibrary
{
    public class SomeHelperLibrary1 : ISomeHelperLibrary1
    {
        private readonly ILogger<SomeHelperLibrary1> _logger;

        public SomeHelperLibrary1(ILogger<SomeHelperLibrary1> logger)
        {
            _logger = logger;
        }

        public Task<string> SomeHelper()
        {
            _logger?.LogInformation($"{nameof(SomeHelperLibrary1)} -> {nameof(SomeHelper)}");
            return Task.FromResult("SomeHelperLibrary1.SomeHelper");
        }
    }
}