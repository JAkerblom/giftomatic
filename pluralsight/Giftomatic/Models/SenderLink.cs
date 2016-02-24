using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Giftomatic.Models
{
  public class SenderLink
  {
    public int Id { get; set; }
    public string Email { get; set; }
    public string Guid { get; set; }
    //public int RecipientId { get; set; }

    ICollection<ItemRating> ItemRatings { get; set; }
  }
}