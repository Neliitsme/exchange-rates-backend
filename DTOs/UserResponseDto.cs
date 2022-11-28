using System.ComponentModel.DataAnnotations;

namespace exchange_rates_backend.DTOs;

public class UserResponseDto
{
    public int Id { get; set; }
    [EmailAddress] public string Email { get; set; }
}