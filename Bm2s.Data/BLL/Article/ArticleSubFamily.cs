using Bm2s.Data.Utils;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Bm2s.Data.BLL.Article
{
  public class ArticleSubFamily : Table
  {
    [AutoIncrement]
    [PrimaryKey]
    public override int Id { get; set; }  

    [Required]
    [StringLength(250)]
    public string Code { get; set; }

    [Required]
    [StringLength(250)]
    public string Designation { get; set; }

    public string Description { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [Required]
    [StringLength(50)]
    public string AccountingEntry { get; set; }

    [References(typeof(ArticleFamily))]
    public int ArticleFamilyId { get; set; }

    [Ignore]
    public ArticleFamily ArticleFamily { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.ArticleFamily = Datas.Instance.DataStorage.ArticleFamilies.FirstOrDefault(arfa => arfa.Id == this.ArticleFamilyId);
    }
  }
}
