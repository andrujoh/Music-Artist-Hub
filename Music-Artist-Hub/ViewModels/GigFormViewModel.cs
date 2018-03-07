using Music_Artist_Hub.Controllers;
using Music_Artist_Hub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Music_Artist_Hub.ViewModels
{
  public class GigFormViewModel
  {
    public int Id { get; set; }

    [Required]
    public string Venue { get; set; }

    [Required]
    [FutureDate]
    public string Date { get; set; }

    [Required]
    [ValidTime]
    public string Time { get; set; }

    [Required]
    public byte Genre { get; set; }


    public IEnumerable<Genre> Genres { get; set; }

    public string Heading { get; set; }

    public string Action
    {
      get
      {
        Expression<Func<GigsController, ActionResult>> update = (c => c.Update(this));

        Expression<Func<GigsController, ActionResult>> create = (c => c.Create(this));
        //return (Id != 0) ? "Update" : "Create";
        var action = (Id != 0) ? update : create;
        return (action.Body as MethodCallExpression).Method.Name;
      }
    }

    public DateTime GetDateTime()
    {
      return DateTime.Parse(string.Format($"{Date}, {Time}"));
    }
  }
}