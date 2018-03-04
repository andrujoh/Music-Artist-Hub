using Microsoft.AspNet.Identity;
using Music_Artist_Hub.Models;
using Music_Artist_Hub.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Music_Artist_Hub.Controllers
{
  public class GigsController : Controller
  {
    private readonly ApplicationDbContext _context;

    public GigsController()
    {
      _context = new ApplicationDbContext();
    }
    
    [Authorize]
    public ActionResult Create()
    {
      var viewModel = new GigFormViewModel
      {
        Genres = _context.Genres.ToList()
      };

      return View(viewModel);
    }

    [Authorize]
    [HttpPost]
    public ActionResult Create(GigFormViewModel viewModel)
    {

      var gig = new Gig
      {
        ArtistId = User.Identity.GetUserId(),
        DateTime = DateTime.Parse(string.Format($"{viewModel.Date}, {viewModel.Time}")),
        GenreId = viewModel.Genre,
        Venue = viewModel.Venue
      };
      _context.Gigs.Add(gig);
      _context.SaveChanges();

      return RedirectToAction("Index", "Home");
    }
  }
}