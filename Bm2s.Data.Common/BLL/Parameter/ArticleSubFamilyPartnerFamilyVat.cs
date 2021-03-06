﻿using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.BLL.Article;
using Bm2s.Data.Common.BLL.Partner;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  [Alias("Asfv")]
  public class ArticleSubFamilyPartnerFamilyVat : DataRow
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }

    [Default(0)]
    public double Rate { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    [StringLength(50)]
    public string AccountingEntry { get; set; }

    [Alias("ArsfId")]
    [References(typeof(ArticleSubFamily))]
    public int ArticleSubFamilyId { get; set; }

    [Alias("PafaId")]
    [References(typeof(PartnerFamily))]
    public int PartnerFamilyId { get; set; }

    [Alias("VatId")]
    [References(typeof(Vat))]
    public int VatId { get; set; }
  }
}
