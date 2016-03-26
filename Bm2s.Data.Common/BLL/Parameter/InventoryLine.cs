using System.Linq;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class InventoryLine : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    public int Quantity { get; set; }

    [References(typeof(InventoryHeader))]
    public int InventoryHeaderId { get; set; }

    [References(typeof(Article.Article))]
    public int ArticleId { get; set; }
  }
}
