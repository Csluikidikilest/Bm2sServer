﻿using System.ComponentModel.DataAnnotations;
using System.Linq;
using Bm2s.Data.Common.BLL.Partner;
using Bm2s.Data.Common.Utils;
using Bm2s.Data.Utils.BLL;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  [Alias("Apfv")]
  public class ArticlePartnerFamilyVat : DataRow
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

    [Alias("ArtiId")]
    [References(typeof(Article.Article))]
    public int ArticleId { get; set; }

    [Alias("PafaId")]
    [References(typeof(PartnerFamily))]
    public int PartnerFamilyId { get; set; }

    [Alias("VatId")]
    [References(typeof(Vat))]
    public int VatId { get; set; }
  }
}
