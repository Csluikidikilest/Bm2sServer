using System;
using System.ComponentModel.DataAnnotations.Schema;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class Price : Table
  {
    [Default(0)]
    public double BasePrice { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    [References(typeof(Article))]
    public int ArticleId { get; set; }

    [Ignore]
    public Article Article { get; set; }
  }
}
