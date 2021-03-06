﻿using System;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  [Alias("Inhe")]
  public class InventoryHeader : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public DateTime Date { get; set; }

    public int Type { get; set; }
  }
}
