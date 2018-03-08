﻿using Microsoft.AspNet.Identity;
using Music_Artist_Hub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Music_Artist_Hub.Controllers.Api
{
  public class GigsController : ApiController
  {
    private ApplicationDbContext _context;

    public GigsController()
    {
      _context = new ApplicationDbContext();
    }

    [HttpDelete]
    public IHttpActionResult Cancel(int id)
    {
      var userId = User.Identity.GetUserId();
      var gig = _context.Gigs
        .Include(g => g.Attendances.Select(a => a.Attendee))
        .Single(g => g.Id == id && g.ArtistId == userId);
      if (gig.IsCancelled)
      {
        return NotFound();
      }

      gig.Cancel();

      _context.SaveChanges();

      return Ok();
    }
  }
}
