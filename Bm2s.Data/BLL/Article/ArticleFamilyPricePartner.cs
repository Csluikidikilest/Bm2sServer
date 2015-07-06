using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Article
{
  public class ArticleFamilyPricePartner
  {
    public decimal Price { get; set; }
    public decimal Multiplier { get; set; }
    public ArticleFamily ArticleFamily { get; set; }
    public Partner.Partner Partner { get; set; }
  }
}
