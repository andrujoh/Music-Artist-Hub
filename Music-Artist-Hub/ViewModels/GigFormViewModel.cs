using Music_Artist_Hub.Models;
using System;
using System.Collections.Generic;

namespace Music_Artist_Hub.ViewModels
{
  public class GigFormViewModel
  {
    public string Venue { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public byte Genre { get; set; }
    public IEnumerable<Genre> Genres { get; set; }
    public DateTime DateTime
    {
      get
      {
        return DateTime.Parse(string.Format($"{Date}, {Time}"));
      }
    }
  }
}