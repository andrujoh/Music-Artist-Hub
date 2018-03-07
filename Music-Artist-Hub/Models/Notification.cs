using System;
using System.ComponentModel.DataAnnotations;

namespace Music_Artist_Hub.Models
{
  public class Notification
  {
    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public NotificationType Type { get; set; }

    // Only used when gig is updated
    public DateTime? OriginalDateTime { get; set; }
    public string OriginalVenue { get; set; }

    [Required]
    public Gig Gig { get; set; }
  }
}