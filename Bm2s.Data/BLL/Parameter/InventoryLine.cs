using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class InventoryLine
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    public int Quantity { get; set; }

    [References(typeof(InventoryHeader))]
    public int InventoryHeaderId { get; set; }

    [References(typeof(Article.Article))]
    public int ArticleId { get; set; }
  }
}
