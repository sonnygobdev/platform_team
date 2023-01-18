using APIK8S.Helpers;
using APIK8S.Models;
using APIK8S.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace APIK8S.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuoteController : ControllerBase
    {
       

        private readonly ILogger<QuoteController> _logger;
        private readonly ApplicationOptions _options;
        private readonly QuoteService _quoteService;

        public QuoteController(ILogger<QuoteController> logger, IOptions<ApplicationOptions> options,QuoteService quoteService)
        {
            _logger = logger;
            _options = options.Value;
            _quoteService = quoteService;   
        }

        [HttpGet(Name = "GetQuote")]
        public async Task<Quote> Get() =>
            await _quoteService.GetRandomQuote();
        

            
    }
}