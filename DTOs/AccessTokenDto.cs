namespace exchange_rates_backend.DTOs;

public class AccessTokenDto
{
    public string AccessToken { get; set; }
    public DateTime ValidTo { get; set; }
}