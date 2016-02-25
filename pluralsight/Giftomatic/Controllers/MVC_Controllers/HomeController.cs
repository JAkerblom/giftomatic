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
  [HandleError]
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


      // TODO:
      //  - Fill indexView with inviting sales material.
      //  - Implement links 1. directly to the user form, or
      //     2. a field for creating link to send to some relative
      //  - :2.:-> A user will get a link with Guid appended, which
      //     is connected to the user's email in a SenderLinks database.
      //    :2.:-> The link may also get a link with relation baked into it,
      //     i.e. /<Guid>/Spouse/, /<Guid>/Sibling/.
      return View();
    }

    public ActionResult GiftPrediction()
    {
      ViewBag.Message = "The start of the gift prediction section.";
      
      // TODO:
      //  - Fill userFormView with relevant form elements and questions
      //  - Fill predictionResultView with angular loop
      //  - Implement storing of userFeatures and return of id
      //  - Implement rerouting to predictionResultView 
      //  - Implement a post service to Azure, either before or after
      //     reroute to predictionResultView. This combines userFeatures
      //     with respective external features, as well as all the items
      //     and their respective item features. Then it either posts 
      //  - Implement storing of prediction results and user item ratings
      //  - Implement mail service for sending to link creator.
      //  - Implement rerouting to some "aftermath" page, like StatisticsView
      return View();
    }

    public ActionResult Statistics()
    {
      ViewBag.Message = "Your stats page.";

      //var stats = _repo.GetStats()
      //                .ToList();

      var stats = "";

      // TODO: 
      //  - Gather suggestions on indicators that may be of use
      //  - Implement the gets from database that aggregates these indicators
      //  - Find suitable visualizer - e.g. d3 or whatever does the trick together
      //     with the angular.JS solution.
      return View(stats);
    }

    public ActionResult About()
    {
      ViewBag.Message = "Your app description page.";

      // TODO: 
      //  - Fill about view with content about app. Include sales material etc-
      return View();
    }

    public ActionResult ManageModel()
    {
      ViewBag.Message = "Your page for managing the model content.";
      
      // TODO:
      //  - Implement login re-route 
      //  - Implement 1. item adder, 2. model retrainer, 3. retrain feedback 
      return View();
    }

        /*
    [HttpPost]
    public ActionResult Train(UserFeatureSet form_data)
    {      
      return View();
    }

    [HttpPost]
    public ActionResult Predict(UserFeatureSet form_data)
    {
        return View();
    }
        */

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
