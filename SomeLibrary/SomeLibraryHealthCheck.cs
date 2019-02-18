using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;

namespace SomeLibrary
{
    public class SomeLibraryHealthCheck : IHealthCheck
    {
        private static readonly Random Random = new Random();
        private readonly ILogger<SomeLibraryHealthCheck> _logger;

        public SomeLibraryHealthCheck(ILogger<SomeLibraryHealthCheck> logger)
        {
            _logger = logger;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            var nextRandom = Random.Next(1, 99);
            var healthMsg = $"random value was {nextRandom}";
            HealthCheckResult healthCheckResult;
            switch (nextRandom)
            {
                case var n when n < 33:
                    healthCheckResult = HealthCheckResult.Healthy(healthMsg);
                    break;
                case var n when n < 66:
                    healthCheckResult = HealthCheckResult.Degraded(healthMsg);
                    break;
                default:
                    healthCheckResult = HealthCheckResult.Unhealthy(healthMsg);
                    break;
            }

            _logger?.LogInformation($"SomeLibrary Health check: {healthCheckResult}");
            return Task.FromResult(healthCheckResult);
        }
    }
}