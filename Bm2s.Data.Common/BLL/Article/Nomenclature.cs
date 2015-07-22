using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using ServiceStack.DataAnnotations;
using Bm2s.Data.Common.Utils;

namespace Bm2s.Data.Common.BLL.Article
{
  public class Nomenclature : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(0)]
    public int? Quantity { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    public double BuyPrice { get; set; }

    [References(typeof(Article))]
    public int ArticleParentId { get; set; }

    [Ignore]
    public Article ArticleParent { get; set; }

    [References(typeof(Article))]
    public int ArticleChildId { get; set; }

    [Ignore]
    public Article ArticleChild { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.ArticleParent = Datas.Instance.DataStorage.Articles.FirstOrDefault<Article>(item => item.Id == this.ArticleParentId);
      this.ArticleChild = Datas.Instance.DataStorage.Articles.FirstOrDefault<Article>(item => item.Id == this.ArticleChildId);
    }
  }
}
