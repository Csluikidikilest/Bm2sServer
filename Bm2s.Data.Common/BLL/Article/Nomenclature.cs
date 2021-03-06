﻿using System;
using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Article
{
  [Alias("Nome")]
  public class Nomenclature : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(1)]
    public double QuantityChild { get; set; }

    public double BuyPrice { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [Alias("ArpaId")]
    [References(typeof(Article))]
    public int ArticleParentId { get; set; }

    [Alias("ArchId")]
    [References(typeof(Article))]
    public int ArticleChildId { get; set; }
  }
}
