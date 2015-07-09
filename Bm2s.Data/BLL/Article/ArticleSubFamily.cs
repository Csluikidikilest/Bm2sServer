using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  [Table("ArticleSubFamily", Schema = "Article")]
  public class ArticleSubFamily
  {
    [AutoIncrement]
    [PrimaryKey]
    public int Id { get; private set; }

    [Required]
    [StringLength(50)]
    public string Code { get; set; }

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
  }
}
