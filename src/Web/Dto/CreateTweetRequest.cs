using System.ComponentModel.DataAnnotations;

namespace Web.Dto;

public class CreateTweetRequest
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public string Content { get; set; } = default!;
    public DateTime? Date { get; set; }
}