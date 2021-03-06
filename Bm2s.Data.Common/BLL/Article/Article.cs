﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.BLL.Parameter;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Article
{
  [Alias("Arti")]
  public class Article : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Designation { get; set; }

    public string Description { get; set; }

    public string Observation { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [Alias("ArfaId")]
    [References(typeof(ArticleFamily))]
    public int ArticleFamilyId { get; set; }

    [Alias("ArsfId")]
    [References(typeof(ArticleSubFamily))]
    public int ArticleSubFamilyId { get; set; }

    [Alias("BranId")]
    [References(typeof(Brand))]
    public int BrandId { get; set; }

    [Alias("UnitId")]
    [References(typeof(Unit))]
    public int UnitId { get; set; }
  }
}
