using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Partner;

namespace Bm2s.Data.BLL.Parameter
{
  public class ArticleFamilyPartnerVat
  {
    public decimal Rate { get; set; }
    public decimal Multiplier { get; set; }
    public string AccountingEntry { get; set; }
    public ArticleFamily ArticleFamily { get; set; }
    public Partner.Partner PartnerFamily { get; set; }
    public Vat Vat { get; set; }
  }
}
