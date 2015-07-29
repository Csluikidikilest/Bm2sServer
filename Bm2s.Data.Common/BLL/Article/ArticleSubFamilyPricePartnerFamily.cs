using System;
using System.Linq;
using Bm2s.Data.Common.BLL.Partner;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Article
{
  public class ArticleSubFamilyPricePartnerFamily : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(0)]
    public double? Price { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(ArticleSubFamily))]
    public int ArticleSubFamilyId { get; set; }

    [Ignore]
    public ArticleSubFamily ArticleSubFamily { get; set; }

    [References(typeof(PartnerFamily))]
    public int PartnerFamilyId { get; set; }

    [Ignore]
    public PartnerFamily PartnerFamily { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.ArticleSubFamily = Datas.Instance.DataStorage.ArticleSubFamilies.FirstOrDefault<ArticleSubFamily>(item => item.Id == this.ArticleSubFamilyId);
      this.PartnerFamily = Datas.Instance.DataStorage.PartnerFamilies.FirstOrDefault<PartnerFamily>(item => item.Id == this.PartnerFamilyId);
    }
  }
}
