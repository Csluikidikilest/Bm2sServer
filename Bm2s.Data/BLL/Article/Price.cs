using System;
using ServiceStack.DataAnnotations;

namespace Bm2s.Data.BLL.Article
{
  public class Price
  {
    [AutoIncrement] [PrimaryKey] public int Id { get; private set; }
    public decimal FullPrice { get; set; }
    public decimal Multiplier { get; set; }
    public DateTime StartingDate { get; set; }
    public DateTime? EndingDate { get; set; }
    [References(typeof(Article))] public int ArticleId { get; set; }
  }
}
