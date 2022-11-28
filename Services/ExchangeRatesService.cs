using System.Text;
using System.Xml.Serialization;
using exchange_rates_backend.Models;

namespace exchange_rates_backend.Services;

public class ExchangeRatesService : IExchangeRatesService
{
    private const string ExchangeRatesUrl = "https://www.cbr.ru/scripts/XML_daily.asp";
    private const string ExchangeRatesUrlDateParam = "?date_req=";

    public async Task<IEnumerable<ValuteEntity>> FetchAndParse(string? date = null)
    {
        try
        {
            var client = new HttpClient();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var responseBody = date is null
                ? await client.GetStringAsync(ExchangeRatesUrl)
                : await client.GetStringAsync(ExchangeRatesUrl + ExchangeRatesUrlDateParam + date);

            var serializer = new XmlSerializer(typeof(ValCursEntity));
            var reader = new StringReader(responseBody);
            var valCurs = serializer.Deserialize(reader) as ValCursEntity;
            reader.Close();

            if (valCurs != null) return valCurs.Valutes;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }

        return Enumerable.Empty<ValuteEntity>();
    }
}