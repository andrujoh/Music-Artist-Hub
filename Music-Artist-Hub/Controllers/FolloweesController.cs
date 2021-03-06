﻿using Microsoft.AspNet.Identity;
using Music_Artist_Hub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Artist_Hub.Controllers
{
  public class FolloweesController : Controller
  {
    private ApplicationDbContext _context;

    public FolloweesController()
    {
      _context = new ApplicationDbContext();
    }

    public ActionResult Index()
    {
      var userId = User.Identity.GetUserId();
      var artists = _context.Followings
          .Where(f => f.FollowerId == userId)
          .Select(f => f.Followee)
          .ToList();

      return View(artists);
    }
  }
}