using System.ComponentModel.DataAnnotations;

namespace Web.Dto;

public class FollowUserRequest
{
    [Required]
    public Guid UserToBeFollowedId { get; set; }
}