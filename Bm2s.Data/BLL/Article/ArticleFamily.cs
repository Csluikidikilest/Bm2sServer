using Bm2s.Data.Utils;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Bm2s.Data.BLL.Article
{
  public class ArticleFamily : Table
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

    [Ignore]
    public List<ArticleSubFamily> ArticleSubFamilies { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.ArticleSubFamilies = Datas.Instance.DataStorage.ArticleSubFamilies.Where(arsf => arsf.ArticleFamilyId == this.Id).ToList();
    }
  }
}
