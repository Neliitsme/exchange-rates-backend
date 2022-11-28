using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace exchange_rates_backend.Models;

public class UserEntity
{
    [Key] public int Id { get; set; }

    [Required]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }

    [MinLength(6)] [Required] public string Password { get; set; }
}