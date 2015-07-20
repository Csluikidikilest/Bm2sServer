using ServiceStack.DataAnnotations;

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
  }
}
