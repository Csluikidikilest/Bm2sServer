using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Partner;

namespace Bm2s.Data.BLL.Parameter
{
  public class ArticleSubFamilyPartnerFamilyVat
  {
    public decimal Rate { get; set; }
    public decimal Multiplier { get; set; }
    public string AccountingEntry { get; set; }
    public ArticleSubFamily ArticleFamily { get; set; }
    public PartnerFamily PartnerFamily { get; set; }
    public Vat Vat { get; set; }
  }
}
