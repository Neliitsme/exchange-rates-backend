using exchange_rates_backend.Models;

namespace exchange_rates_backend.Services;

public interface IExchangeRatesService
{
    Task<IEnumerable<ValuteEntity>> FetchAndParse(string? date = null);
}