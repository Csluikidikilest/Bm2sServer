﻿using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Parameter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bm2s.Data.BLL.Trade
{
  public class HeaderLine
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    public int LineNumber { get; set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Designation { get; set; }

    public string Description { get; set; }

    [Default(0)]
    public double BuyPrice { get; set; }

    public double SellPrice { get; set; }

    [Default(1)]
    public int Quantity { get; set; }

    public string PreparationObservation { get; set; }

    public string DeliveryObservation { get; set; }

    public string SupplierCompanyName { get; set; }

    public double VatRate { get; set; }

    public bool IsPrintable { get; set; }

    [References(typeof(Article.Article))]
    public int ArticleId { get; set; }

    [References(typeof(ArticleFamily))]
    public int ArticleFamilyId { get; set; }

    [References(typeof(ArticleSubFamily))]
    public int ArticleSubFamilyId { get; set; }

    [References(typeof(Brand))]
    public int BrandId { get; set; }

    [References(typeof(HeaderLineType))]
    public int HeaderLineTypeId { get; set; }

    [References(typeof(Header))]
    public int HeaderId { get; set; }

    [References(typeof(Unit))]
    public int UnitId { get; set; }
  }
}
