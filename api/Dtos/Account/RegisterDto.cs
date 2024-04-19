using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Account
{
    public record RegisterDto(
      [Required] string? username,
      [Required][EmailAddress] string? email,
      [Required] string? password
      );

}
