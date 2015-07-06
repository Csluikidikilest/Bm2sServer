using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Parameter
{
  public class InventoryLine
  {
    public int Quantity { get; set;}
    public InventoryHeader InventoryHeader { get; set; }
    public Article.Article Article { get; set; }
  }
}
