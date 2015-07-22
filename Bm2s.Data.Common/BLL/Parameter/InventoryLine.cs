using System.Linq;
using ServiceStack.DataAnnotations;
using Bm2s.Data.Common.Utils;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class InventoryLine : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public int Quantity { get; set; }

    [References(typeof(InventoryHeader))]
    public int InventoryHeaderId { get; set; }

    [Ignore]
    public InventoryHeader InventoryHeader { get; set; }

    [References(typeof(Article.Article))]
    public int ArticleId { get; set; }

    [Ignore]
    public Article.Article Article { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.InventoryHeader = Datas.Instance.DataStorage.InventoryHeaders.FirstOrDefault<InventoryHeader>(item => item.Id == this.InventoryHeaderId);
      this.Article = Datas.Instance.DataStorage.Articles.FirstOrDefault<Article.Article>(item => item.Id == this.ArticleId);
    }
  }
}
