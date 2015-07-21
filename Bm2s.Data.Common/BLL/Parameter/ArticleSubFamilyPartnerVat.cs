﻿using Bm2s.Data.Common.BLL.Article;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.Common.BLL.Parameter
{
  public class ArticleSubFamilyPartnerVat : Table
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

    [References(typeof(ArticleSubFamily))]
    public int ArticleSubFamilyId { get; set; }

    [Ignore]
    public ArticleSubFamily ArticleSubFamily { get; set; }

    [References(typeof(Partner.Partner))]
    public int PartnerId { get; set; }

    [Ignore]
    public Partner.Partner Partner { get; set; }

    [References(typeof(Vat))]
    public int VatId { get; set; }
  }
}