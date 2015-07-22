using Bm2s.Data.Common.BLL.Parameter;
using Bm2s.Data.Common.Utils;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace Bm2s.Data.Common.BLL.Article
{
  public class Subscription : Table
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

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Article))]
    public int ArticleId { get; set; }

    [Ignore]
    public Article Article { get; set; }

    [References(typeof(Period))]
    public int PeriodId { get; set; }

    [Ignore]
    public Period Period { get; set; }

    public override void LazyLoad()
    {
      base.LazyLoad();
      this.Article = Datas.Instance.DataStorage.Articles.FirstOrDefault<Article>(item => item.Id == this.ArticleId);
      this.Period = Datas.Instance.DataStorage.Periods.FirstOrDefault<Period>(item => item.Id == this.PeriodId);
    }
  }
}
