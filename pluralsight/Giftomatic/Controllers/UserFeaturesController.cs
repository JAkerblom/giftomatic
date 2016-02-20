using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Giftomatic.Data;
using Giftomatic.Models;

namespace Giftomatic.Controllers
{
  public class UserFeaturesController : ApiController
  {
    private IPredictionDataRepository _repo;
    public UserFeaturesController(IPredictionDataRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<UserFeatureSet> Get(bool includeItemRatings = false, bool include)
    {
      IQueryable<UserFeatureSet> results;

      if (includeItemRatings == true)
      {
        results = _repo.GetUserFeatureSetsIncludingItemRatings();
      }
      else
      {
        results = _repo.GetTopics();
      }

      var topics = results.OrderByDescending(t => t.Created)
                          .Take(25)
                          .ToList();

      return topics;
    }

    // I didn't show this, but this is common
    public HttpResponseMessage Get(int id, bool includeReplies = false)
    {
      IQueryable<Topic> results;

      if (includeReplies == true)
      {
        results = _repo.GetTopicsIncludingReplies();
      }
      else
      {
        results = _repo.GetTopics();
      }

      var topic = results.Where(t => t.Id == id).FirstOrDefault();

      if (topic != null) return Request.CreateResponse(HttpStatusCode.OK, topic);

      return Request.CreateResponse(HttpStatusCode.NotFound);
    }

    public IEnumerable<ItemFeatureSet> Get

    public HttpResponseMessage Post([FromBody]Topic newTopic)
    {
      if (newTopic.Created == default(DateTime))
      {
        newTopic.Created = DateTime.UtcNow;
      }

      if (_repo.AddTopic(newTopic) &&
          _repo.Save())
      {
        return Request.CreateResponse(HttpStatusCode.Created,
          newTopic);
      }

      return Request.CreateResponse(HttpStatusCode.BadRequest);
    }
  }
}
