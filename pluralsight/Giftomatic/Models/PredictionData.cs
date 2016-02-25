using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Giftomatic.Models
{
  public class PredictionData
  {
    public UserFeatureSet UserFeatures { get; set; }
    public ItemFeatureSet ItemFeatures { get; set; }
    public ExternalFeatureSet ExternalFeatures { get; set; }
  }
}