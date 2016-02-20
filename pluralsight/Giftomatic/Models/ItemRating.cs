using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Giftomatic.Models
{
  public class ItemRating
  {
    public int ItemId { get; set; }
    public DateTime Created { get; set; }
    public int UserId { get; set; }
    public int Rating { get; set; }
        
  }
}