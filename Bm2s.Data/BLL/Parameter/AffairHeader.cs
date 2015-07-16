﻿using Bm2s.Data.BLL.Trade;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class AffairHeader : Table
  {
    [References(typeof(Affair))]
    public int AffairId { get; set; }

    [Ignore]
    public Affair Affair { get; set; }

    [References(typeof(Header))]
    public int HeaderId { get; set; }

    [Ignore]
    public Header Header { get; set; }
  }
}
