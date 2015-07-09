using System.Collections.Generic;
using Bm2s.Data.BLL.Article;
using Bm2s.Data.BLL.Parameter;
using System;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bm2s.Data.BLL.Partner
{
  public class PartnerFamily
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

    [InverseProperty("PartnerFamily")]
    public List<ArticleFamilyPricePartnerFamily> ArticleFamilyPricePartnerFamilies { get; set; }

    [InverseProperty("PartnerFamily")]
    public List<ArticlePriceParnerFamily> ArticlePriceParnerFamilys { get; set; }

    [InverseProperty("PartnerFamily")]
    public List<ArticleSubFamilyPricePartnerFamily> ArticleSubFamilyPricePartnerFamilies { get; set; }

    [InverseProperty("PartnerFamily")]
    public List<ArticleFamilyPartnerFamilyVat> ArticleFamilyPartnerFamilyVats { get; set; }

    [InverseProperty("PartnerFamily")]
    public List<ArticlePartnerFamilyVat> ArticlePartnerFamilyVats { get; set; }

    [InverseProperty("PartnerFamily")]
    public List<ArticleSubFamilyPartnerFamilyVat> ArticleSubFamilyPartnerFamilyVats { get; set; }

    [InverseProperty("PartnerFamily")]
    public List<PartnerPartnerFamily> PartnerPartnerFamilies { get; set; }
  }
}
