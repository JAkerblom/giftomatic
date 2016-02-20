using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Giftomatic.Models
{
  public class ExternalFeatureSet
  {
    public string Zip { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string AgeGroup { get; set; }
    public double Assets { get; set; }

    //public ICollection<Re> Replies { get; set; }
  }
}