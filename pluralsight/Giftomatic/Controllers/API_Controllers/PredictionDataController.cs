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
  public class PredictionDataController : ApiController
  {
    private IPredictionDataRepository _repo;

    // Rekommenderar att flytta den här injection till repot
    private IAzureService _azure;
    public PredictionDataController(IPredictionDataRepository repo, IAzureService azure)
    {
      _repo = repo;
      _azure = azure;
    }

    public HttpResponseMessage Get()
    {
      IQueryable<ExternalFeatureSet> efs;


      return Request.CreateResponse(HttpStatusCode.NotFound);
    }

    public HttpResponseMessage Post([FromBody]PredictionData data)
    {
      var result = _azure.GetPrediction(data, 1);
      
      if (result != null)
      {
        //JObject jsonObj = JObject.Parse(result);
        //var predictedItems = jsonObj["Results"]["output1"]["value"]["Values"];
        var predictedItems = result["Results"]["output1"]["value"]["Values"];

        return Request.CreateResponse(HttpStatusCode.Created, predictedItems);
      }

      return Request.CreateResponse(HttpStatusCode.BadRequest);
    }

    public HttpResponseMessage Post([FromBody]UserFeatureSet usf, int modelNr)
    {
      JObject result = _repo.GetPrediction(usf, modelNr);

      return Request.CreateResponse(HttpStatusCode.BadRequest);
    }

    public HttpResponseMessage Post([FromBody]ASUserFeatureSet usf, int modelNr)
    {
      JObject result = _repo.GetPrediction(usf, modelNr);

      if (result != null)
      {
        return Request.CreateResponse(HttpStatusCode.OK, result);
      }

      return Request.CreateResponse(HttpStatusCode.BadRequest);
    }
  }
}
