﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bm2s.Data.BLL.Partner;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Parameter
{
  public class ArticlePartnerFamilyVat
  {
    [Default(0)]
    public double Rate { get; set; }

    [Default(1)]
    public double? Multiplier { get; set; }

    [Required]
    [StringLength(50)]
    public string AccountingEntry { get; set; }

    [PrimaryKey]
    [References(typeof(Article.Article))]
    public int ArticleId { get; set; }

    [ForeignKey("ArticleId")]
    public Article.Article Article { get; set; }

    [PrimaryKey]
    [References(typeof(PartnerFamily))]
    public int PartnerFamilyId { get; set; }

    [ForeignKey("PartnerFamilyId")]
    public PartnerFamily PartnerFamily { get; set; }

    [PrimaryKey]
    [References(typeof(Vat))]
    public int VatId { get; set; }

    [ForeignKey("VatId")]
    public Vat Vat { get; set; }
  }
}
