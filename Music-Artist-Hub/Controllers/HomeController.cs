﻿using Music_Artist_Hub.Models;
using Music_Artist_Hub.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Music_Artist_Hub.Controllers
{
  public class HomeController : Controller
  {
    private ApplicationDbContext _context;

    public HomeController()
    {
      _context = new ApplicationDbContext();
    }
    public ActionResult Index()
    {
      var upcomingGigs = _context.Gigs
        .Include(g => g.Artist)
        .Include(g => g.Genre)
        .Where(g => g.DateTime > DateTime.Now && !g.IsCancelled);

      var viewModel = new GigsViewModel
      {
        UpcomingGigs = upcomingGigs,
        ShowActions = User.Identity.IsAuthenticated,
        Heading = "Upcoming Gigs"
      };
      return View("Gigs", viewModel);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your application description page.";

      return View();
    }

    public ActionResult Contact()
    {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}