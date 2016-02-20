using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Giftomatic.Models
{
  public class ItemFeatureSet
  {
    public int ItemId { get; set; }
    public string ItemName { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ProductGroup { get; set; }
    public bool IsExpensive { get; set; }

    //public ICollection<Re> Replies { get; set; }
  }
}