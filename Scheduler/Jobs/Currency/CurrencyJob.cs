using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Scheduler.Jobs.Currency
{
    public class CurrencyJob : ICurrencyJob
    {
        private readonly HttpClient _httpClient;
        private readonly CurrencyOptions _options;
        private ILogger _logger;

        public CurrencyJob(IOptions<CurrencyOptions> options, ILoggerFactory loggerFactory)
        {
            _options = options.Value;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_options.Token}");
            _logger = loggerFactory.CreateLogger<CurrencyJob>();
        }

        public async Task Run()
        {
            _logger.LogInformation($"Running { nameof(CurrencyJob) }");
            await _httpClient.PostAsync(new Uri(_options.Endpoint), new StringContent(""));
        }
    }
}