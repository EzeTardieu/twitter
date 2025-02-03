using System.ComponentModel.DataAnnotations;

namespace Web.Dto;

public class CreateUserRequest
{
    [Required]
    public string Name { get; set; } = default!;
    [Required]
    public string Email { get; set; } = default!;
}