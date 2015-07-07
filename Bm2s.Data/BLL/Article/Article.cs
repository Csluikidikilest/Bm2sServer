using System;
using System.ComponentModel.DataAnnotations;
using Bm2s.Data.BLL.Parameter;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{

  public class Article
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(50)]
    public string Code { get; set; }

    [StringLength(250)]
    public string Designation { get; set; }

    public string Description { get; set; }

    public decimal? SellPrice { get; set; }

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
