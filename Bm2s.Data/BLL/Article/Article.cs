using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bm2s.Data.BLL.Parameter;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  [Table("Article", Schema = "Article")]
  public class Article
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Designation { get; set; }

    public string Description { get; set; }

    public double? SellPrice { get; set; }

    public string Observation { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(ArticleFamily))]
    public int ArticleFamilyId { get; set; }

    [ForeignKey("ArticleFamilyId")]
    public ArticleFamily ArticleFamily { get; set; }

    [References(typeof(ArticleSubFamily))]
    public int ArticleSubFamilyId { get; set; }

    [ForeignKey("ArticleSubFamilyId")]
    public ArticleSubFamily ArticleSubFamily { get; set; }

    [References(typeof(Brand))]
    public int BrandId { get; set; }

    [ForeignKey("BrandId")]
    public Brand Brand { get; set; }

    [References(typeof(Unit))]
    public int UnitId { get; set; }

    [ForeignKey("UnitId")]
    public Unit Unit { get; set; }

    [InverseProperty("Article")]
    public List<ArticlePriceParnerFamily> ArticlePriceParnerFamilies { get; set; }

    [InverseProperty("Article")]
    public List<Price> Prices { get; set; }

    [InverseProperty("Article")]
    public List<ArticlePartnerVat> ArticlePartnerVats { get; set; }

    [InverseProperty("Article")]
    public List<ArticlePartnerFamilyVat> ArticlePartnerFamilyVats { get; set; }

    [InverseProperty("InventoryHeader")]
    public List<InventoryLine> InventoryLines { get; set; }
  }
}
