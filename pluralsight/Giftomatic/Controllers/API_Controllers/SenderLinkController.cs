using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Giftomatic.Data;
using Giftomatic.Models;
using Newtonsoft.Json.Linq;

namespace Giftomatic.Controllers
{
  public class SenderLinkController : ApiController
  {
    private IPredictionDataRepository _repo;

    public SenderLinkController(IPredictionDataRepository repo)
    {
      _repo = repo;
    }

    public HttpResponseMessage Get(string senderId, bool includePredictions = true)
    {
      IQueryable<SenderLink> result;

      if (includePredictions)
      {
        result = _repo.GetSenderIncludingPredictions(senderId);
      }
      else
      {
        result = _repo.GetSender(senderId);
      }

      SenderLink sender = result.Single();

      if (sender != null) return Request.CreateResponse(HttpStatusCode.OK, sender);

      return Request.CreateResponse(HttpStatusCode.NotFound);
    }

    public HttpResponseMessage Post([FromBody]SenderLink newSender)
    {
      var guid = new Guid();
      newSender.Guid = guid.ToString();

      if (_repo.AddSenderLink(newSender))
      {
        return Request.CreateResponse(HttpStatusCode.Created, newSender);
      }

      return Request.CreateResponse(HttpStatusCode.NotFound);
    }
  }
}
