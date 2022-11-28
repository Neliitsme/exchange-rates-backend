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
    public async Task<ActionResult<IEnumerable<ValuteEntity>>> GetByDate(string? date)
    {
        IEnumerable<ValuteEntity> valutes;
        if (date is null)
        {
            valutes = await _exchangeRatesService.FetchAndParse();
        }
        else
        {
            var decodedDate = HttpUtility.UrlDecode(date);
            var parsedDate = DateOnly.Parse(decodedDate);
            valutes = await _exchangeRatesService.FetchAndParse(parsedDate.ToString());
        }

        if (!valutes.Any())
        {
            return NotFound();
        }

        return Ok(valutes);
    }
}