using System;
using Bm2s.Poco.Common.Parameter;

namespace Bm2s.Poco.Common.Article
{
  public class Article
  {
    public int Id { get; set; }

    public string Code { get; set; }

    public string Designation { get; set; }

    public string Description { get; set; }

    public string Observation { get; set; }

    public DateTime StartingDate { get; set; }

    public DateTime? EndingDate { get; set; }

    public ArticleFamily ArticleFamily { get; set; }

    public ArticleSubFamily ArticleSubFamily { get; set; }

    public Brand Brand { get; set; }

    public Unit Unit { get; set; }
  }
}
