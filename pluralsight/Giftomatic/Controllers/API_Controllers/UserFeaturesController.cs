using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Giftomatic.Data;
using Giftomatic.Models;
using Newtonsoft.Json.Linq;

namespace Giftomatic.Controllers.API_Controllers
{
  public class UserFeaturesController : ApiController
  {
    private IPredictionDataRepository _repo;
    public UserFeaturesController(IPredictionDataRepository repo)
    {
      _repo = repo;
    }

    //public IEnumerable<UserFeatureSet> Get(bool includeItemRatings = false)
    //{
      //IQueryable<UserFeatureSet> results;

      //if (includeItemRatings == true)
      //{
      //  results = _repo.GetUserFeatureSetsIncludingItemRatings();
      //}
      //else
      //{
      //  results = _repo.GetUserFeatures();
      //}

      //var userInputs = results.OrderByDescending(i => i.Created)
      //                    .Take(25)
      //                    .ToList();

      //return userInputs;
      
    //}

    // I didn't show this, but this is common
    //public HttpResponseMessage Get(int id, bool includeItemRatings = false)
    //{
    //  IQueryable<UserFeatureSet> results;

    //  if (includeItemRatings == true)
    //  {
    //    //results = _repo.GetUserFeatureSetsIncludingItemRatings();
    //  }
    //  else
    //  {
    //    //results = _repo.GetUserFeatures();
    //  }

    //  var topic = results.Where(t => t.Id == id).FirstOrDefault();

    //  if (topic != null) return Request.CreateResponse(HttpStatusCode.OK, topic);

    //  return Request.CreateResponse(HttpStatusCode.NotFound);
    //}

    //public IEnumerable<ItemFeatureSet> Get

    public HttpResponseMessage Post([FromBody]UserFeatureSet newSetOfUserFeatures)
    {
      if (newSetOfUserFeatures.Created == default(DateTime))
      {
        newSetOfUserFeatures.Created = DateTime.UtcNow;
      }

      if (_repo.AddUserFeatureSet(newSetOfUserFeatures) &&
          _repo.SaveUser())
      {
        return Request.CreateResponse(HttpStatusCode.Created,
          newSetOfUserFeatures);
      }

      return Request.CreateResponse(HttpStatusCode.BadRequest);
    }

    public HttpResponseMessage Post([FromBody]UserFeatureSet newSetOfUserFeatures, string senderId = null)
    {
        if (newSetOfUserFeatures.Created == default(DateTime))
        {
            newSetOfUserFeatures.Created = DateTime.UtcNow;
        }
        if (senderId != null)
        {
          var sender = _repo.GetSender(senderId).FirstOrDefault(); 
        }
        
        var newUser = _repo.AddUserFeatureSet(newSetOfUserFeatures);

        if (newUser)
        {
            return Request.CreateResponse(HttpStatusCode.Created,
                newUser);
        }

        return Request.CreateResponse(HttpStatusCode.BadRequest);
    }
  }
}
