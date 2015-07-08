using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Article;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class ArticleSubFamilyPartnerVat
  {
    [Default(0)]
    public double Rate { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    public string AccountingEntry { get; set; }

    public ArticleSubFamily ArticleFamily { get; set; }

    public Partner.Partner PartnerFamily { get; set; }

    public Vat Vat { get; set; }
  }
}
