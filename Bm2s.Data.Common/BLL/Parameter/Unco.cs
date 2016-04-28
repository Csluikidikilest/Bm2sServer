﻿using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class Unco : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(0)]
    public int Quantity { get; set; }

    [Default(1)]
    public int Multiplier { get; set; }

    [References(typeof(Unit))]
    public int UnchId { get; set; }

    [References(typeof(Unit))]
    public int UnpaId { get; set; }
  }
}