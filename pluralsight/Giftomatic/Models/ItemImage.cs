﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Giftomatic.Models
{
  public class ItemImage
  {
    public int Id { get; set; }
    public byte[] Image { get; set; }
    public int ItemId { get; set; }
  }
}