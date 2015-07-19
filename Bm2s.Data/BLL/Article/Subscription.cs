using Bm2s.Data.BLL.Parameter;
using ServiceStack.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bm2s.Data.BLL.Article
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
  }
}
