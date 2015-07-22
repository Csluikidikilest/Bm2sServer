using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack.DataAnnotations;
using System;
using System.Linq;
using Bm2s.Data.Common.Utils;

namespace Bm2s.Data.Common.BLL.Article
{
  public class ArticleSubFamilyPricePartner : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(0)]
    public double? Price { get; set; }

    public bool AddPrice { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(ArticleSubFamily))]
    public int ArticleSubFamilyId { get; set; }

    [Ignore]
    public ArticleSubFamily ArticleSubFamily { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [Ignore]
    public Partner.Partner Partner { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.ArticleSubFamily = Datas.Instance.DataStorage.ArticleSubFamilies.FirstOrDefault<ArticleSubFamily>(item => item.Id == this.ArticleSubFamilyId);
      this.Partner = Datas.Instance.DataStorage.Partners.FirstOrDefault<Partner.Partner>(item => item.Id == this.PartnerId);
    }
  }
}
