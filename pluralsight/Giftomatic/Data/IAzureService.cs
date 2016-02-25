using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giftomatic.Models;
using Newtonsoft.Json.Linq;

namespace Giftomatic.Data
{
  public interface IAzureService
  {
    //IEnumerable<int> GetPrediction(UserFeatureSet ufs, ItemFeatureSet ifs, ExternalFeatureSet efs);
    JObject GetPrediction(PredictionData data, int modelNr);
    JObject GetPrediction(UserFeatureSet usf, int modelNr);
    JObject GetPrediction(ASUserFeatureSet usf, int modelNr);
  }
}
