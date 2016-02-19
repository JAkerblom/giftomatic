using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Giftomatic.Data;
using Giftomatic.Models;
using Giftomatic.Services;

namespace Giftomatic.Controllers
{
  public class HomeController : Controller
  {
    //private IMailService _mail;
    private IMessageBoardRepository _repo;

        //public HomeController(IMailService mail, IMessageBoardRepository repo)
    public HomeController(IMessageBoardRepository repo)
    {
      //_mail = mail;
      _repo = repo;
    }

    public ActionResult Index()
    {
      ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

      //var topics = _repo.GetTopics()
      //                  .OrderByDescending(t => t.Created)
      //                  .Take(25)
      //                  .ToList();

      return View(topics);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your app description page.";

      return View();
    }

    public ActionResult Statistics()
    {
      ViewBag.Message = "Your stats page.";

      var stats = _repo.GetStats()
                      .ToList();
       
      return View(stats);
    }

    [HttpPost]
    public ActionResult Train(UserInput form_data)
    {      
      return View();
    }

    [HttpPost]
    public ActionResult Predict(UserInput form_data)
    {
        return View();
    }

        //[Authorize]
        //public ActionResult MyMessages()
        //{
        //  return View();
        //}

        //[Authorize(Roles="Admin")]
        //public ActionResult Moderation()
        //{
        //  return View();
        //}
    }
}
