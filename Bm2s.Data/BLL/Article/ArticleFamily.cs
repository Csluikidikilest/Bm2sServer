using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bm2s.Data.BLL.Parameter;
using Bm2s.Data.BLL.Trade;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class ArticleFamily
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

    [InverseProperty("ArticleFamily")]
    public List<Article> Articles { get; set; }

    [InverseProperty("ArticleFamily")]
    public List<ArticleFamilyPricePartner> ArticleFamilyPricePartners { get; set; }

    [InverseProperty("ArticleFamily")]
    public List<ArticleSubFamily> ArticleSubFamilies { get; set; }

    [InverseProperty("ArticleFamily")]
    public List<ArticleFamilyPartnerVat> ArticleFamilyPartnerVats { get; set; }

    [InverseProperty("ArticleFamily")]
    public List<ArticleFamilyPartnerFamilyVat> ArticleFamilyPartnerFamilyVats { get; set; }

    [InverseProperty("ArticleFamily")]
    public List<HeaderLine> HeaderLines { get; set; }
  }
}
