using System.Web;
using exchange_rates_backend.Models;
using exchange_rates_backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exchange_rates_backend.Controllers;

[Route("api/quotation")]
[ApiController]
public class ExchangeRatesController : ControllerBase
{
    private readonly IExchangeRatesService _exchangeRatesService;

    public ExchangeRatesController(IExchangeRatesService exchangeRatesService)
    {
        _exchangeRatesService =
            exchangeRatesService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IEnumerable<ValuteEntity>> GetByDate(string? date)
    {
        if (date is null)
        {
            return await _exchangeRatesService.FetchAndParse();
        }

        var decodedDate = HttpUtility.UrlDecode(date);
        var parsedDate = DateOnly.Parse(decodedDate);
        return await _exchangeRatesService.FetchAndParse(parsedDate.ToString());
    }
}