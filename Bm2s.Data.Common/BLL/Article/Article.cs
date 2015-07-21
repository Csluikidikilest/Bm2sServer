using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using Bm2s.Data.Common.BLL.Parameter;
using Bm2s.Data.Common.Utils;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Article
{
  public class Article : Table
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

    [References(typeof(ArticleFamily))]
    public int ArticleFamilyId { get; set; }

    [Ignore]
    public ArticleFamily ArticleFamily { get; set; }

    [References(typeof(ArticleSubFamily))]
    public int ArticleSubFamilyId { get; set; }

    [Ignore]
    public ArticleSubFamily ArticleSubFamily { get; set; }

    [References(typeof(Brand))]
    public int BrandId { get; set; }

    [Ignore]
    public Brand Brand { get; set; }

    [References(typeof(Unit))]
    public int UnitId { get; set; }

    [Ignore]
    public Unit Unit { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.ArticleFamily = Datas.Instance.DataStorage.ArticleFamilies.FirstOrDefault<ArticleFamily>(item => item.Id == this.ArticleFamilyId);
      this.ArticleSubFamily = Datas.Instance.DataStorage.ArticleSubFamilies.FirstOrDefault<ArticleSubFamily>(item => item.Id == this.ArticleSubFamilyId);
      this.Brand = Datas.Instance.DataStorage.Brands.FirstOrDefault<Brand>(item => item.Id == this.BrandId);
      this.Unit = Datas.Instance.DataStorage.Units.FirstOrDefault<Unit>(item => item.Id == this.UnitId);
    }
  }
}
