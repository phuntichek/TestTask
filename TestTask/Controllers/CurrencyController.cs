using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestTask.Service;
using TestTask.Data;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        private readonly ILogger<CurrencyController> _logger;

        public CurrencyController(ICurrencyService currencyService, ILogger<CurrencyController> logger)
        {
            _currencyService = currencyService;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("AddCurrencyExchange")]
        public void AddCurrencyExchange()
        {
            _logger.LogDebug("Status: ", _currencyService.AddNewCurrencyState());
        }
    }
}
