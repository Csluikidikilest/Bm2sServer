using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Article
{
  public class Nomenclature
  {
    public int Quantity { get; set; }
    public decimal BuyPrice { get; set; }
    public Article ArticleParent { get; set; }
    public Article ArticleChild { get; set; }
  }
}
