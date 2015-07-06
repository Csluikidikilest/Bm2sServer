using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bm2s.Data.BLL.Article
{
  public class ArticlePriceParnerFamily
  {
    public decimal Price { get; set; }
    public decimal Multiplier { get; set; }
    public Article Article { get; set; }
    public Partner.PartnerFamily PartnerFamily { get; set; }
  }
}
