using Music_Artist_Hub.Models;
using System.Collections.Generic;

namespace Music_Artist_Hub.ViewModels
{
  public class GigsViewModel
  {
    public IEnumerable<Gig> UpcomingGigs { get; set; }
    public bool ShowActions { get; set; }
    public string Heading { get; set; }
  }
}