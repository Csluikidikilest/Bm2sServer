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
    public int Quantity { get; set;}

    public int InventoryHeaderId { get; set; }

    [References(typeof(InventoryHeader))]
    public int InventoryHeaderId { get; set; }

    [ForeignKey("InventoryHeaderId")]
    public InventoryHeader InventoryHeader { get; set; }

    [References(typeof(Article.Article))]
    public int ArticleId { get; set; }

    [ForeignKey("ArticleId")]
    public Article.Article Article { get; set; }
  }
}
