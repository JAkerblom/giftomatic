using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Giftomatic.Models;

namespace Giftomatic.Data
{
  public interface IAzureService
  {
    //IEnumerable<int> GetPrediction(UserFeatureSet ufs, ItemFeatureSet ifs, ExternalFeatureSet efs);
    string GetPrediction(PredictionDataCollection data);
  }
}
