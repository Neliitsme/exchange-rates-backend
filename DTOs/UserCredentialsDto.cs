using System.ComponentModel.DataAnnotations;

namespace exchange_rates_backend.DTOs;

public class UserCredentialsDto
{
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [Required]
    public string Email { get; set; }

    [MinLength(6)] [Required] public string Password { get; set; }
}