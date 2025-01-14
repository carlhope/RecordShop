using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using RecordShop.Api.Controllers;
using RecordShop.Business.Services;
using RecordShop.Common.Models;
using RecordShop.DataAccess.Repositories;

namespace RecordShop.Api
{
    public class HealthChecks : IHealthCheck
    {
        private readonly ILogger _logger;
        private ArtistService _artistService;

        public HealthChecks(ILogger logger, ArtistService artistService)
        {
            _logger = logger;
            _artistService = artistService;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var healthy = await CheckGetProducts();
            if (healthy.IsSuccess)
            {
                return HealthCheckResult.Healthy(healthy.Message);
            }
            else
            {
                return HealthCheckResult.Unhealthy(healthy.Message);
            }
            
        }

        private async Task<OperationResult> CheckGetProducts()
        {
            OperationResult result = new();
            var data = await _artistService.GetAllAsync();
            if (data==null)
            {
                result.Message = "Failed to return list of results";
                result.IsSuccess = false;
                _logger.LogCritical(result.Message);
            }
            else
            {
                result.Message = "Success";
                result.IsSuccess = true;
                _logger.LogInformation(result.Message);
            }
            return result;
        }
    }
}
