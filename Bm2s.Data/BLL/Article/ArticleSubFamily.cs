using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bm2s.Data.BLL.Parameter;
using Bm2s.Data.BLL.Trade;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class ArticleSubFamily
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

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(ArticleFamily))]
    public int ArticleFamilyId { get; set; }

    [ForeignKey("ArticleFamilyId")]
    public ArticleFamily ArticleFamily { get; set; }

    [InverseProperty("ArticleSubFamily")]
    public List<Article> Articles { get; set; }

    [InverseProperty("ArticleSubFamily")]
    public List<ArticleSubFamilyPricePartner> ArticleSubFamilyPricePartners { get; set; }

    [InverseProperty("ArticleSubFamily")]
    public List<ArticleSubFamilyPricePartnerFamily> ArticleSubFamilyPricePartnerFamilies { get; set; }

    [InverseProperty("ArticleSubFamily")]
    public List<ArticleSubFamilyPartnerVat> ArticleSubFamilyPartnerVats { get; set; }

    [InverseProperty("ArticleSubFamily")]
    public List<ArticleSubFamilyPartnerFamilyVat> ArticleSubFamilyPartnerFamilyVats { get; set; }

    [InverseProperty("ArticleSubFamily")]
    public List<HeaderLine> HeaderLines { get; set; }
  }
}
