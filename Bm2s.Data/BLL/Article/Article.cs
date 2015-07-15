using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bm2s.Data.BLL.Parameter;
using Bm2s.Data.BLL.Trade;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class Article
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Designation { get; set; }

    public string Description { get; set; }

    public double? SellPrice { get; set; }

    public string Observation { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(ArticleFamily))]
    public int ArticleFamilyId { get; set; }

    [References(typeof(ArticleSubFamily))]
    public int ArticleSubFamilyId { get; set; }

    [References(typeof(Brand))]
    public int BrandId { get; set; }

    [References(typeof(Unit))]
    public int UnitId { get; set; }
  }
}
