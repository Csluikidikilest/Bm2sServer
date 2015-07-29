using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.BLL.Article;
using Bm2s.Data.Common.BLL.Parameter;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Trade
{
  public class HeaderLine : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public int LineNumber { get; set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Designation { get; set; }

    public string Description { get; set; }

    [Default(0)]
    public double BuyPrice { get; set; }

    public double SellPrice { get; set; }

    [Default(1)]
    public int Quantity { get; set; }

    public string PreparationObservation { get; set; }

    public string DeliveryObservation { get; set; }

    public string SupplierCompanyName { get; set; }

    public double VatRate { get; set; }

    public bool IsPrintable { get; set; }

    [References(typeof(Article.Article))]
    public int ArticleId { get; set; }

    [Ignore]
    public Article.Article Article { get; set; }

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

    [References(typeof(HeaderLineType))]
    public int HeaderLineTypeId { get; set; }

    [Ignore]
    public HeaderLineType HeaderLineType { get; set; }

    [References(typeof(Header))]
    public int HeaderId { get; set; }

    [Ignore]
    public Header Header { get; set; }

    [References(typeof(Unit))]
    public int UnitId { get; set; }

    [Ignore]
    public Unit Unit { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Article = Datas.Instance.DataStorage.Articles.FirstOrDefault<Article.Article>(item => item.Id == this.ArticleId);
      this.ArticleFamily = Datas.Instance.DataStorage.ArticleFamilies.FirstOrDefault<ArticleFamily>(item => item.Id == this.ArticleFamilyId);
      this.ArticleSubFamily = Datas.Instance.DataStorage.ArticleSubFamilies.FirstOrDefault<ArticleSubFamily>(item => item.Id == this.ArticleSubFamilyId);
      this.Brand = Datas.Instance.DataStorage.Brands.FirstOrDefault<Brand>(item => item.Id == this.BrandId);
      this.HeaderLineType = Datas.Instance.DataStorage.HeaderLineTypes.FirstOrDefault<HeaderLineType>(item => item.Id == this.HeaderLineTypeId);
      this.Header = Datas.Instance.DataStorage.Headers.FirstOrDefault<Header>(item => item.Id == this.HeaderId);
      this.Unit = Datas.Instance.DataStorage.Units.FirstOrDefault<Unit>(item => item.Id == this.UnitId);
    }
  }
}
