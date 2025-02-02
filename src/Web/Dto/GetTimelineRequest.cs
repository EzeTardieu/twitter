using System.ComponentModel.DataAnnotations;

namespace Web.Dto;

public class GetTimelineRequest
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public int Page { get; set; }
    [Required]
    public int PageSize { get; set; }
}